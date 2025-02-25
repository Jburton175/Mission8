using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission8.Models
{
    public class Mission8DBContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<Categories> Category { get; set; }

        public Mission8DBContext(DbContextOptions<Mission8DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.category_id);
        }
    }
}
