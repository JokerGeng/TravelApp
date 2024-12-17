using Microsoft.EntityFrameworkCore;

namespace TravelApp.Models
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet 代表数据库中的表
        public DbSet<User> Users { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 可在这里配置模型关系或约束
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
