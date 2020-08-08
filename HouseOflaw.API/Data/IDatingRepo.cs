using System.Collections.Generic;
using System.Threading.Tasks;
using HouseOflaw.API.Models;

namespace HouseOflaw.API.Data
{
    public interface IDatingRepo
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(double Code);
    }
}