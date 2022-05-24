using Todo.Core;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Models;
using Todo.Models.DTOs;
using IResult = Todo.Core.Utilities.Results.IResult;


namespace Todo.Business.Abstract
{
    public interface IAuthenticationService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
