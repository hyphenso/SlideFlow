using Microsoft.EntityFrameworkCore;
using DigitalSignageAPI.Models;

namespace DigitalSignageAPI.Data
{
    public class SignageContext : DbContext
    {
        public SignageContext(DbContextOptions<SignageContext> options)
            : base(options) { }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Slide> Slides { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Attribute-based mapping is used
        }

    }
}
