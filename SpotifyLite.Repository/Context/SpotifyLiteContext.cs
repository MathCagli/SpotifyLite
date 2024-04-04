using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Notificacao;
using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Models.Transacao.Agreggates;

namespace SpotifyLite.Repository.Context
{
    public class SpotifyLiteContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Banda> Bandas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }

        public SpotifyLiteContext(DbContextOptions<SpotifyLiteContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotifyLiteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}