using entityf.Contracts;
using entityf.Data.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthMenager _authMenager;
        public AccountController(IAuthMenager authMenager)
        {
            this._authMenager = authMenager;
        }

        //api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserReg apiUserReg)
        {
            var errors = await _authMenager.RegisterUser(apiUserReg);

            if (errors.Any()) 
            { 
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        //api/Account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] ApiUserLog apiUserLog)
        {
            var authresponse = await _authMenager.Login(apiUserLog);

            if (authresponse is null)
            {
                return Unauthorized();
            }

            return Ok(authresponse);
        }
    }
}
