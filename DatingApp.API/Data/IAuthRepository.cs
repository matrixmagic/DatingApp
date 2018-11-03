using DatingApp.Models;
using System.Threading.Tasks;
namespace DatingApp.Data
{
    public interface IAuthRepository
    {
        Task<User>Regiser(User user,string password );
        Task<User>Login(string username,string password);
        Task<bool>UserExisits(string username);
         
    }
}