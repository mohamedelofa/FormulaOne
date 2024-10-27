using FormulaOne.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(
                    e => e.HasMany(d => d.Achievements)
                    .WithOne(a => a.Driver)
                    .HasForeignKey(a => a.DriverId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Drivers_Achievements")
            );
        }
    }
}
