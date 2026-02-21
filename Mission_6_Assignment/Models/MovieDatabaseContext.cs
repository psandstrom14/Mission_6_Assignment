using Microsoft.EntityFrameworkCore;

namespace Mission_6_Assignment.Models
{
    public class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base (options) 
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
