using Microsoft.EntityFrameworkCore;

namespace homework.Models {
    public class UniversityContext : DbContext {
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Students> Students { get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options) 
            : base(options) {
            Database.EnsureCreated();
        }
    }
}
