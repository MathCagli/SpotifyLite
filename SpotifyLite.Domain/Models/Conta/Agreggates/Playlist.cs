using SpotifyLite.Domain.Models.Streaming.Agreggates;

namespace SpotifyLite.Domain.Models.Conta.Agreggates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Publica { get; set; }
        public DateTime DtCriacao { get; set; }

        public Usuario Usuario { get; set; }
        public List<Musica> Musicas { get; set; }

    }
}

