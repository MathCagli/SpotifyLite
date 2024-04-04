namespace SpotifyLite.Domain.Models.Streaming.Agreggates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual List<Musica> Musica { get; set; } = new List<Musica>();


        public void AdicionarMusica(Musica musica) =>
            Musica.Add(musica);
        public void AdicionarMusica(List<Musica> musica) =>
            Musica.AddRange(musica);

        public Album CriarAlbum(string nome)
        {
            Nome = nome;

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("Informe o nome da Album.");

            return new Album()
            {
                Nome = nome
            };
        }
    }
}
