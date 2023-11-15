using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taro.Core.Entities.Models.CourseModels;

namespace Taro.Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Video> videos { get; set; }
    }
}
