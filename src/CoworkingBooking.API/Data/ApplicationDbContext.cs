using Microsoft.EntityFrameworkCore;
using CoworkingBooking.API.Models;

namespace CoworkingBooking.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        // При необходимости здесь можно добавить конфигурации моделей через Fluent API
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     // Пример конфигурации:
        //     // modelBuilder.Entity<Booking>().ToTable("Bookings");
        // }
    }
}