using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace homework.Models
{
    public class GuestBookContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Messages> Message { get; set; }

        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                SaveChanges();
            }
        }
    }
}