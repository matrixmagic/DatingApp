using System;
using System.Threading.Tasks;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore;
namespace DatingApp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.Include(p => p.photos).FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;

            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

                return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
              using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

               
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for( int i =0 ;i<computedHash.Length;i++){
                if(computedHash[i]!=passwordHash[i])
                return false;

                }
                 

            }
            return true;
        }

        public async Task<User> Regiser(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePassordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        private void CreatePassordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


            }
        }

        public async Task<bool> UserExisits(string username)
        {
            if(await _context.User.AnyAsync(x=>x.Username==username))
            return true;
            return false;
        }
    }
}