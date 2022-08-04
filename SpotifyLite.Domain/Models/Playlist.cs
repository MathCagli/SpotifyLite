using SpotifyLite.CrossCutting.Entity;

namespace SpotifyLite.Domain.Models
{
    public class Playlist : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        public virtual IList<Musica> Musicas { get; set; }
    }
}
