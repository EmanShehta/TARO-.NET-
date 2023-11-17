using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Core.Entities.Roles;

namespace Taro.Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,Role,string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Video> videos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });
        }
    }
}
