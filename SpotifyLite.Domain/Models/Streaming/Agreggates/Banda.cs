using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Core.ValueObject;
using SpotifyLite.Domain.Models.Notificacao;
using SpotifyLite.Domain.Models.Transacao.Agreggates;
using SpotifyLite.Domain.Models.Transacao.ValueObject;
using System.Numerics;
using System.Text;

namespace SpotifyLite.Domain.Models.Streaming.Agreggates
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Backdrop { get; set; }

        public virtual List<Album> Albums { get; set; } = new List<Album>();

        public void AdicionarAlbum(Album album) =>
            Albums.Add(album);

        public Banda CriarBanda(string nome, string descricao, string backdrop)
        {
            Nome = nome;
            Descricao = descricao;
            Backdrop = backdrop;

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("Informe o nome da Banda.");

            return new Banda()
            {
                Nome = nome,
                Descricao = descricao,
                Backdrop = backdrop
            };
        }
    }
}