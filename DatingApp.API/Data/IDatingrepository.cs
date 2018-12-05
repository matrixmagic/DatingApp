using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Models;

namespace DatingApp.API.Data
{
    public interface IDatingrepository
    {
        void Add<T> (T entity) where T: class;
        void Delete<T> (T entity) where T:class;
        Task <bool> SaveAll();
        Task <IEnumerable<User>> GetUsers();
        Task <User> GetUser(int id);
        Task <Photo> GetPhoto(int id);
        Task <Photo> GetMainPhtoForUserAsync(int userId);
    }
}