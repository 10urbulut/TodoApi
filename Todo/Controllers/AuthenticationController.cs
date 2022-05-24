

using Microsoft.AspNetCore.Mvc;
using Todo.Business.Abstract;
using Todo.Core;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Models;
using Todo.Models.DTOs;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> userToLogin = _authenticationService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            IDataResult<AccessToken> result = _authenticationService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            IResult userExists = _authenticationService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            IDataResult<User> registerResult = _authenticationService.Register(userForRegisterDto);
            IDataResult<AccessToken> result = _authenticationService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}