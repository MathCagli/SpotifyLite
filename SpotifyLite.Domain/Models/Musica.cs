using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.Domain.ValueObject;

namespace SpotifyLite.Domain.Models
{
    public class Musica : Entity<Guid>
    {
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }
        public int Nota { get; set; }
        public int QtdVotos { get; set; }

        public virtual IList<Playlist> Playlists { get; set; }
    }
}
