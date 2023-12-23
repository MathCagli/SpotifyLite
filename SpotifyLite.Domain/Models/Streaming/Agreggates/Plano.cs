using SpotifyLite.Domain.Models.Core.ValueObject;

namespace SpotifyLite.Domain.Models.Streaming.Agreggates
{
    public class Plano
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Monetario Valor { get; set; }
    }
}
