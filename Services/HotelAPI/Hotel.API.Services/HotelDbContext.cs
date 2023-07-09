using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.API.Models;
using Microsoft.Extensions.Configuration;

namespace Hotel.API.Services
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Models.Hotel> Hotels;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=HotelDb;Integrated Security=true;Pooling=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Hotel>().ToTable("Hotels");
            modelBuilder.Entity<Models.Hotel>().HasKey(j => j.UUID);
            modelBuilder.Entity<Models.Hotel>().Property(i => i.Name).HasColumnName("Name");
            base.OnModelCreating(modelBuilder);
        }
    }
}
