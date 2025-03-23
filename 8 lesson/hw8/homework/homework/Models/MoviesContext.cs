using Microsoft.EntityFrameworkCore;

namespace MoviesMVC
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {
                Movies?.Add(new Movies {Name = "Dune: Part Two", Director = "Denis Villeneuve", Genre = "Sci-Fi", YearOfRelease = 2024, Poster = "~/Image/Dune.jpg", Description = "Continuation of Paul Atreides' journey as he unites with the Fremen to take revenge against those who destroyed his family."});
                Movies?.Add(new Movies { Name = "The Gorge", Director = "Scott Derrickson", Genre = "Action", YearOfRelease = 2025, Poster = "~/Image/Gorge.jpg", Description = "A high-octane love story set in a fantasy world, blending action and adventure with a sci-fi twist." });
                Movies?.Add(new Movies { Name = "Marrowbone", Director = "Sergio G. Sánchez", Genre = "Horror", YearOfRelease = 2017, Poster = "~/Image/Marrowbone.jpg", Description = "A group of siblings hide from the outside world in an old house after their mother's death, but dark secrets lurk within." });
                SaveChanges();
            }
        }
    }
}
