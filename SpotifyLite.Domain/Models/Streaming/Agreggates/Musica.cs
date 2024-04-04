using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Notificacao;
using SpotifyLite.Domain.Models.Streaming.ValueObject;
using SpotifyLite.Domain.Models.Transacao.Agreggates;

namespace SpotifyLite.Domain.Models.Streaming.Agreggates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

        public virtual List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public Musica CriarMusica(string nome, Duracao duracao)
        {
            Nome = nome;
            Duracao = duracao;

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("Informe o nome da música");

            if (Duracao.Valor < 1)
                throw new ArgumentNullException("Duração deve ser maior que zero");

            return new Musica()
            {
                Nome = nome,
                Duracao = duracao
            };

        }
    }
}
