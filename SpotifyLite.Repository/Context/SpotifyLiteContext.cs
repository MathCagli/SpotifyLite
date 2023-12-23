using Microsoft.EntityFrameworkCore;

namespace SpotifyLite.Repository.Context
{
    public class SpotifyLiteContext : DbContext
    {

        public SpotifyLiteContext(DbContextOptions<SpotifyLiteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyLiteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
