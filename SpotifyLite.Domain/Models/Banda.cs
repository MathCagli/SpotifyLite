using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.Domain.Factory;

namespace SpotifyLite.Domain.Models
{
    public class Banda : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        public virtual IList<Album> Albuns { get; set; }


        public void CreateAlbum(string nome, IList<Musica> musicas)
        {
            var album = AlbumFactory.Create(nome, musicas);
            this.Albuns.Add(album);
        }

        public int QuantidadeAlbuns()
            => this.Albuns.Count;

        public IEnumerable<Musica> ObterMusicas()
            => this.Albuns.SelectMany(x => x.Musicas).AsEnumerable();

    }
}
