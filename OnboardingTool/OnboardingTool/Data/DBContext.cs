using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization.Infrastructure;
//using System.Reflection.PortableExecutable;
using OnboardingTool.Models.Domain;

namespace OnboardingTool.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<User_courses> User_Courses { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User_roles> User_roles { get; set; }
        public DbSet<log> logs { get; set; }
    }
}
 