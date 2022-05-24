using Todo.Business.Abstract;
using Todo.Core;
using Todo.Core.Utilities.Results;
using Todo.Core.Utilities.Results.DataResult;
using Todo.Models;
using Todo.Models.DTOs;
using IResult = Todo.Core.Utilities.Results.IResult;

namespace Todo.Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, ConstantStrings.TOKEN_OLUSTURULDU);
        }



        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            User? userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck is null)
            {
                return new ErrorDataResult<User>(ConstantStrings.KULLANICI_BULUNAMADI);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(ConstantStrings.PAROLA_HATASI);
            }

            return new SuccessDataResult<User>(userToCheck, ConstantStrings.GIRIS_BASARILI);

        }


        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, ConstantStrings.KAYIT_OLDU);
        }


        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(ConstantStrings.KULLANICI_MEVCUT);
            }
            return new SuccessResult();

        }

        
    }
}
