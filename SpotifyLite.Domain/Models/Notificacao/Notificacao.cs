using SpotifyLite.Domain.Models.Conta.Agreggates;

namespace SpotifyLite.Domain.Models.Notificacao
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public DateTime DtNotificacao { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }

        public Usuario UsuarioDestino { get; set; }
        public Usuario? UsuarioRemetente { get; set; }


        public Notificacao CriarNotificacao(string titulo, string mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario remetente = null)
        {

            DtNotificacao = DateTime.Now;
            Mensagem = mensagem;
            TipoNotificacao = tipoNotificacao;
            Titulo = titulo;
            UsuarioDestino = destino;
            UsuarioRemetente = remetente;

            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
                throw new ArgumentNullException("Para tipo de mensagem 'usuário', você deve informar quem foi o remetente");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Informe o titulo da notificacao");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException("Informe o mensagem da notificacao");

            return new Notificacao()
            {
                DtNotificacao = DateTime.Now,
                Mensagem = mensagem,
                TipoNotificacao = tipoNotificacao,
                Titulo = titulo,
                UsuarioDestino = destino,
                UsuarioRemetente = remetente
            };
        }
    }

    public enum TipoNotificacao
    {
        Usuario = 1,
        Sistema = 2
    }
}
