using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using HouseOflaw.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOflaw.API.Data
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DataContext _context;

        public AuthRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(double Code, string Password)
        {
             var user = await _context.Users.FirstOrDefaultAsync(x => x.Code == Code);
            if (user == null) return null;
            if (!verfiyPasswordHash(Password, user.PasswordSalt, user.PasswordHashed))
            {
                return null;
            }
            return user;
        }

        private bool verfiyPasswordHash(string  password, byte[] passwordSalt, byte[] passwordHashed)
        {
           using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHashed[i])
                    {
                        return false;
                    }
                }
                return true;
        }
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] PasswordHashed, PasswordSalt;
            CreatePasswordHashed(Password, out PasswordHashed, out PasswordSalt);
            user.PasswordHashed = PasswordHashed;
            user.PasswordSalt = PasswordSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHashed(string password, out byte[] passwordHashed, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHashed = hmac.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(double Code)
        {
            if (await _context.Users.AnyAsync(x => x.Code == Code))
            {
                return true;
            }
            return false;
        }
    }
}