using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess
{
    public class MvcDBContext : IdentityDbContext<AppUser, AppRole, int,
     IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
     IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MvcDBContext(DbContextOptions<MvcDBContext> options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasMany(u => u.UserRoles)
            .WithOne(u => u.User).HasForeignKey(u => u.UserId).IsRequired();

            builder.Entity<AppRole>().HasMany(u => u.UserRoles)
            .WithOne(u => u.Role).HasForeignKey(u => u.RoleId).IsRequired();
        }

    }
}
