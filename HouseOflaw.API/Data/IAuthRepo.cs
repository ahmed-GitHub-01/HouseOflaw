using System;
using System.Threading.Tasks;
using HouseOflaw.API.Models;

namespace HouseOflaw.API.Data
{
    public interface IAuthRepo
    {
        Task<User> Login (double Code, string Password);
        Task<User> Register (User user, string Password);
        Task<bool> UserExists(double Code); 
    }
}