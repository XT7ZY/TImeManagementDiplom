using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TImeManagement.Models;
using TImeManagement.Data.Helpers;

namespace TImeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
             
        }

        public DbSet<Bid> bids { get; set; }
        public DbSet<BidType> bidsType { get; set; }
        public DbSet<Day> days { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<Role> roles { get; set; }

    }

    
}
