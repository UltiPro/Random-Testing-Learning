﻿using AutoMapper;
using entityf.Contracts;
using entityf.Data;
using entityf.Data.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace entityf.Repository
{
    public class AuthMenager : IAuthMenager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<APIUser> _userManager;
        private readonly IConfiguration _configuration;
        private APIUser _user;

        private const string _loginProvider = "APIListingHotel";
        private const string _refreshToken = "RefreshToken";

        public AuthMenager(IMapper mapper, UserManager<APIUser> userManager, IConfiguration configuration) 
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResp> Login(ApiUserLog apiUserLog)
        {
            _user = await _userManager.FindByEmailAsync(apiUserLog.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, apiUserLog.Password);

            if (_user is null || !isValidUser)
            {
                return null;
            }

            var token = await GenerateToken();

            return new AuthResp
            {
                Id = _user.Id,
                Token = token,
                RefreshToken = await CreateRefreshToken()
            };
        }

        async Task<IEnumerable<IdentityError>> IAuthMenager.RegisterUser(ApiUserReg apiUserReg)
        {
            var user = _mapper.Map<APIUser>(apiUserReg);

            var result = await _userManager.CreateAsync(user, apiUserReg.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issier"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRegreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRegreshToken);
            return newRegreshToken;
        }

        public async Task<AuthResp> VerifyRefreshToken(AuthResp authResp)
        {
            var jsonSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jsonSecurityTokenHandler.ReadJwtToken(authResp.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            
            _user = await _userManager.FindByNameAsync(username);
            
            if (_user == null || _user.Id != authResp.Id)
            {
                return null;
            }
            
            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, authResp.RefreshToken);

            if(isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResp
                {
                    Token = token,
                    Id = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }
    }
}
