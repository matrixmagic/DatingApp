using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class Datingrepository : IDatingrepository
    {
        private readonly DataContext _context;
        public Datingrepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhtoForUserAsync(int userId)
        {
           return await _context.Photos.Where(U=>U.UserId==userId).FirstOrDefaultAsync(P=>P.IsMain);
        }

        
        public async Task<Photo> GetPhoto(int id)
        {
            var Photo=await _context.Photos.FirstOrDefaultAsync( p =>p.Id==id);
            return Photo;
        }

        public async Task<User> GetUser(int id)
        {
            var User= await _context.User.Include( p=> p.photos).FirstOrDefaultAsync(u =>u.Id==id);
            return User;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
          var users = await _context.User.Include(p=>p.photos).ToListAsync();
          return users;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync()>0;
        }
    }
}