using SpotifyLite.Domain.Models.Streaming.Agreggates;

namespace SpotifyLite.Domain.Models.Conta.Agreggates
{
    public class Assinatura
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtAtivacao { get; set; }

        public virtual Plano Plano { get; set; }
    }
}