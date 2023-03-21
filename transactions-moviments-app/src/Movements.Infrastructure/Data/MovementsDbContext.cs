using Microsoft.EntityFrameworkCore;
using Movements.Infrastructure.Data.Models;

namespace Movements.Infrastructure.Data
{
    public class MovementsDbContext : DbContext
    {
        public DbSet<MovementModel> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovementModel>()
                .ToTable("Movement");
        }
    }
}