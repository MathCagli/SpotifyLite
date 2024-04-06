using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Streaming.Agreggates;

namespace SpotifyLite.Application.DTO
{
    public class PlaylistDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Publica { get; set; }
        public DateTime DtCriacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual List<Musica> Musicas { get; set; }

    }
}