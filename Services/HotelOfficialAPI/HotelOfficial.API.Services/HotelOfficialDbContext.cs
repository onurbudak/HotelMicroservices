using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOfficial.API.Services
{
    public class HotelOfficialDbContext : DbContext
    {
        public HotelOfficialDbContext(DbContextOptions<HotelOfficialDbContext> options) : base(options) { }

        public DbSet<Models.HotelOfficial> HotelOfficials;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=HotelOfficialDb;Integrated Security=true;Pooling=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.HotelOfficial>().ToTable("HotelOfficials");
            modelBuilder.Entity<Models.HotelOfficial>().HasKey(j => j.UUID);
            modelBuilder.Entity<Models.HotelOfficial>().Property(i => i.Name).HasColumnName("Name");
            modelBuilder.Entity<Models.HotelOfficial>().Property(i => i.SurName).HasColumnName("SurName");
            modelBuilder.Entity<Models.HotelOfficial>().Property(i => i.Title).HasColumnName("Title");
            base.OnModelCreating(modelBuilder);
        }
    }
}
