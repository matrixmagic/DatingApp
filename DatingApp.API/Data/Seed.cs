using System.Collections.Generic;
using DatingApp.Models;
using Newtonsoft.Json;

namespace DatingApp.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;

        }
        public void SeedUsers(){
            var userData =System.IO.File.ReadAllText("Data/UserSeedDAta.json");
            var users=JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash,PasswordSalt;
                CreatePassordHash("password",out passwordHash,out PasswordSalt);
                user.PasswordHash=passwordHash;
                user.PasswordSalt=PasswordSalt;
                user.Username=user.Username.ToLower();
                _context.Add(user);

            }
            _context.SaveChanges();
        }
        private void CreatePassordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


            }
        }

    }
}