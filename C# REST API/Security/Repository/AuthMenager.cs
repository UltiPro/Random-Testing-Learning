using AutoMapper;
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
        public AuthMenager(IMapper mapper, UserManager<APIUser> userManager, IConfiguration configuration) 
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResp> Login(ApiUserLog apiUserLog)
        {
            var user = await _userManager.FindByEmailAsync(apiUserLog.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, apiUserLog.Password);

            if (user is null || !isValidUser)
            {
                return null;
            }

            var token = await GenerateToken(user);

            return new AuthResp
            {
                Id = user.Id,
                Token = token
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

        private async Task<string> GenerateToken(APIUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
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
    }
}
