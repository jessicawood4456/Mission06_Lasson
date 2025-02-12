using Microsoft.EntityFrameworkCore;

namespace Mission06_Lasson.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options) // Constructor
        { 
        
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
