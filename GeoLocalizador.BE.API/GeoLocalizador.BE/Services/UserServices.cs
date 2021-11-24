using GeoLocalizador.BE.Dao;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Services
{
    public class UserServices
    {
        private readonly UserDao _context;
        private readonly IConfiguration _configuration;
        public UserServices(UserDao context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Result<IEnumerable<UserResponse>> Get()
        {
            IEnumerable<UserResponse> _result = _context.Get();
            return new Result<IEnumerable<UserResponse>>(_result);
        }
        public Result<dynamic> CheckCredencials(string _username, string _password)
        {
            UserResponse _user = _context.CheckCredencials(_username, _password);
            if (_user !=  null)
            {
                if (_user.Status == false)
                {
                    throw new Exception("O usuario não tem mais acesso a aplicação");
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                string _secret = _configuration.GetSection("Secret").Value;
                var key = Encoding.ASCII.GetBytes(_secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, _user.Username.ToString()),
                    new Claim(ClaimTypes.Role, _user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var Itoken = tokenHandler.WriteToken(token);                
                return new Result<dynamic>(new
                {
                    user = _user,
                    token = Itoken
                });
            }
            throw new Exception("O usuario não foi encontrado");
        }
        public Result<bool> Set(User _user)
        {
            bool _result = _context.Set(_user);
            return new Result<bool>(_result);
        }
        public Result<bool> UpdatePassword(int id, User _user)
        {
            bool _result = _context.UpdatePassword(id, _user);
            return new Result<bool>(_result);
        }
        public Result<bool> TurnOnAccess(int id)
        {
            bool _result = _context.TurnOnAccess(id);
            return new Result<bool>(_result);
        }
        public Result<bool> TurnOffAccess(int id)
        {
            bool _result = _context.TurnOffAccess(id);
            return new Result<bool>(_result);
        }

    }
}
