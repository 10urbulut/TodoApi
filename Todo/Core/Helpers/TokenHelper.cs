

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Todo.Core.DTOs;
using Todo.Models;

namespace Todo.Core
{

    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration _configuration { get; }
        private TokenOptionsDto _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("JWT").Get<TokenOptionsDto>();

        }
        public AccessToken CreateToken(User user)
        {

            _accessTokenExpiration = DateTime.Now.AddHours(1);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = SignInCredentialsHelper.CreateSigningCredentials(securityKey);
            SecurityToken jwt = CreateJwtSecurityToken(signingCredentials);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new ();
            string token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(
            SigningCredentials signingCredentials)
        {
            JwtSecurityToken jwt = new(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}