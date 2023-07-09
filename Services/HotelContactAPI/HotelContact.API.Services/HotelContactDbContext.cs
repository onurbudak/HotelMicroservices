using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelContact.API.Services
{
    public class HotelContactDbContext : DbContext
    {
        public HotelContactDbContext(DbContextOptions<HotelContactDbContext> options) : base(options) { }

        public DbSet<Models.HotelContact> HotelContacts;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=HotelContactDb;Integrated Security=true;Pooling=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.HotelContact>().ToTable("HotelContacts");
            modelBuilder.Entity<Models.HotelContact>().HasKey(j => j.UUID);
            modelBuilder.Entity<Models.HotelContact>().Property(i => i.Phone).HasColumnName("Phone");
            modelBuilder.Entity<Models.HotelContact>().Property(i => i.Email).HasColumnName("Email");
            modelBuilder.Entity<Models.HotelContact>().Property(i => i.Location).HasColumnName("Location");
            modelBuilder.Entity<Models.HotelContact>().Property(i => i.Content).HasColumnName("Content");
            base.OnModelCreating(modelBuilder);
        }
    }
}
