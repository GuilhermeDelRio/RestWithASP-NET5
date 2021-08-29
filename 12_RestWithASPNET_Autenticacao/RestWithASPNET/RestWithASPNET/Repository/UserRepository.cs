using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET.Repository {
    public class UserRepository : IUserRepository {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context) {
            _context = context;
        }

        public User ValidateCredentials(UserVO user) {

            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            
            // retorna a senha criptografada se for igual ao do banco de dados.
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User RefreshUserInfo(User user) {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if(result != null) {
                try {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                } catch (Exception) {

                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm) {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
