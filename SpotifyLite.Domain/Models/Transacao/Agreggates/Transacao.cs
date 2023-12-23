using SpotifyLite.Domain.Models.Core.ValueObject;
using SpotifyLite.Domain.Models.Transacao.ValueObject;

namespace SpotifyLite.Domain.Models.Transacao.Agreggates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime DtTransacao { get; set; }
        public string Descricao { get; set; }

        public Monetario Valor { get; set; }
        public Merchant Merchant { get; set; }
    }
}
