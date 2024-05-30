using Microsoft.EntityFrameworkCore;
using PlaneSpotterApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PlaneSpotterApi.Context
{
    public class PlaneSpotterContext : DbContext
    {
        public PlaneSpotterContext(DbContextOptions<PlaneSpotterContext> options) : base(options)
        {
        }

        public DbSet<AirlineSighting> AirlineSightings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AirlineSighting>()
                .HasOne(s => s.CreatedUser)
                .WithMany(u => u.CreatedSightings)
                .HasForeignKey(s => s.CreatedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AirlineSighting>()
                .HasOne(s => s.ModifiedUser)
                .WithMany(u => u.ModifiedSightings)
                .HasForeignKey(s => s.ModifiedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
