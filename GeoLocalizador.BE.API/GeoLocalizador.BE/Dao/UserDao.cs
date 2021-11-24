using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace GeoLocalizador.BE.Dao
{
    public class UserDao
    {
        private readonly GeoContext _context;
        public UserDao(GeoContext context)
        {
            _context = context;
        }
        public IEnumerable<UserResponse> Get()
        {
            IEnumerable<UserResponse> _result = 
                (from user in _context.Users.ToList()
                         select new UserResponse
                         {
                             Name = user.Name,
                             Surname = user.Surname,
                             Username = user.Username,
                             Role = user.Role
                         });

            return _result;
        }
        public UserResponse CheckCredencials(string _username, string _password) 
        {
            UserResponse _result =
                   (from user in _context.Users.ToList()
                    where user.Username == _username &&
                    user.Password == _password
                    select new UserResponse
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Username = user.Username,
                        Role = user.Role,
                        Status = user.Status
                    }).FirstOrDefault();
            return _result;
        }
        public bool Set(User _user) 
        {
            _context.Users.Add(_user);
            return (_context.SaveChanges() > 0);
        }
        public bool UpdatePassword(int id, User _user)
        {
            User _result = _context.Users.Find(id);
            if (_result != null)
            {
                _result.Password = _user.Password;
                return (_context.SaveChanges() > 0);
            }
            return false;
        }
        public bool TurnOnAccess(int id)
        {
            User _result = _context.Users.Find(id);
            if (_result != null)
            {
                _result.Status = true;
                return (_context.SaveChanges() > 0);
            }
            return false;
        }
        public bool TurnOffAccess(int id)
        {
            User _result = _context.Users.Find(id);
            if (_result != null)
            {
                _result.Status = false;
                return (_context.SaveChanges() > 0);
            }
            return false;
        }

    }
}
