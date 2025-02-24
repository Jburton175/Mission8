using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission8.Models
{
    public class Mission8DBContext : DbContext
    {
        public DbSet<Task> Task { get; set; }
        public DbSet<Categories> Category { get; set; }

    }
}
