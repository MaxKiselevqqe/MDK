using CIS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CIS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UsersDB> UsersDB {  get; set; }
        public DbSet<Games> Games { get; set; }


        public DbSet<Cart> Carts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
