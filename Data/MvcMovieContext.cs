using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;


namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext()
        {
        }
        public DbContextOptions<MvcMovieContext> Options { get; }
        
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
            this.Options = options;
        }

        public DbSet<Movie> Movie { get; set; }
    }
}