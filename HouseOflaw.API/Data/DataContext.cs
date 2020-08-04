using HouseOflaw.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseOflaw.API.Data 
{
    public class DataContext: DbContext
    {
        public  DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<User> Users { get; set; }
    }
}