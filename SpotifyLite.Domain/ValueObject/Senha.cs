namespace SpotifyLite.Domain.ValueObject
{
    public class Senha
    {
        public Senha()
        {

        }
        public Senha(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Senha));
        }

        public string Valor { get; set; }
    }
}
