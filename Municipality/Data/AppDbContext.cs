using Microsoft.EntityFrameworkCore;
using Municipality.Entities;
using System.Security.Principal;
using Municipality.Entities.PastureModule;

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
        public DbSet<News> News { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Pasture> Pastures { get; set; }
        public DbSet<PasturePayment> PasturePayments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
