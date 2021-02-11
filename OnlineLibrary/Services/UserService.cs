using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineLibrary.Data;
using OnlineLibrary.Helpers;
using OnlineLibrary.Models;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext g_dbContext;

        public UserService(ApplicationDbContext context)
        {
            g_dbContext = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = g_dbContext.Users.SingleOrDefault(x => x.Username == username);
            if (user == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return g_dbContext.Users;
        }

        public User GetById(int id)
        {
            return g_dbContext.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }
            if (g_dbContext.Users.Any(x => x.Username == user.Username))
            {
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            }
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            g_dbContext.Users.Add(user);
            g_dbContext.SaveChanges();
            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty.", "password");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty.", "password");
            }
            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }
            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[ i ] != storedHash[ i ]) return false;
                }
            }
            return true;
        }
    }
}