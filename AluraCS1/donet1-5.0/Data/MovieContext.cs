using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace donet1_5._0.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opt) : base (opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
