using georgiev_grigoriy_kt_31_22.Database.Configurations;
using georgiev_grigoriy_kt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace georgiev_grigoriy_kt_31_22.Database
{
    public class CafedraDbContext : DbContext
    {
        public DbSet<Cafedra> Cafedras { get; set; }
        public DbSet<Prepods> Prepods { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<Nagruzka> Nagruzki { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CafedraConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
            modelBuilder.ApplyConfiguration(new NagruzkaConfiguration());
            modelBuilder.ApplyConfiguration(new PositionsConfiguration());
            modelBuilder.ApplyConfiguration(new PrepodsConfiguration());
        }
        public CafedraDbContext(DbContextOptions<CafedraDbContext> options) : base(options)
        { }
    }
}