using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Lasson.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) // Constructor
        { 
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}
