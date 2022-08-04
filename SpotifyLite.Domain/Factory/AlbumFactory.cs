using SpotifyLite.Domain.Models;

namespace SpotifyLite.Domain.Factory
{
    public static class AlbumFactory
    {
        public static Album Create(string nome, Musica musica)
        {
            if (musica == null)
                throw new ArgumentNullException("O albúm precisa ter pelo menos uma música.");

            return new Album()
            {
                Musicas = new List<Musica>() { musica }
            };
        }

        public static Album Create(string nome, IEnumerable<Musica> musicas)
        {
            if (!musicas.Any())
                throw new ArgumentNullException("O albúm precisa ter pelo menos uma música.");

            return new Album()
            {
                Musicas = musicas.ToList()
            };

        }
    }
}
