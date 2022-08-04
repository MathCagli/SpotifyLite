using SpotifyLite.CrossCutting.Entity;

namespace SpotifyLite.Domain.Models
{
    public class Album : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Capa { get; set; }

        public virtual IList<Musica> Musicas { get; set; }

    }
}