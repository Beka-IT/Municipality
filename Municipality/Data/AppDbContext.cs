using Microsoft.EntityFrameworkCore;
using Municipality.Entities;
using System.Security.Principal;

namespace Municipality.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<AgricultureArea> AgricultureAreas { get; set; }
        public DbSet<AgriculturalLand> AgriculturalLands { get; set; }
        public DbSet<Irrigation> Irrigations { get; set; }
        public DbSet<IrrigationPayment> IrrigationPayments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
