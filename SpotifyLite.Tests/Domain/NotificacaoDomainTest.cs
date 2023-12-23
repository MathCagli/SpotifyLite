using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Notificacao;

namespace SpotifyLite.Tests.Domain
{
    public class NotificacaoDomainTest
    {
        [Fact]
        public void DeveCriarNotificacaoComSucesso()
        {
            string titulo = "Título de Teste";
            string mensagem = "Mensagem de Teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Sistema;

            Usuario destino = new Usuario();
            Notificacao notificacao = new Notificacao();
            notificacao.CriarNotificacao(titulo, mensagem, tipoNotificacao, destino);

            Assert.True(notificacao.Titulo == titulo);
            Assert.True(notificacao.Mensagem == mensagem);
            Assert.True(notificacao.TipoNotificacao == tipoNotificacao);
            Assert.True(notificacao.UsuarioDestino == destino);
        }

        [Fact]
        public void NaoDeveCriarNotificacaoSemTitulo()
        {
            string titulo = "";
            string mensagem = "Mensagem de Teste";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();

            Assert.Throws<ArgumentNullException>(() =>
            {
                Notificacao notificacao = new Notificacao();
                notificacao.CriarNotificacao(titulo, mensagem, tipoNotificacao, destino);
            });
        }

        [Fact]
        public void NaoDeveCriarNotificacaoSemMensagem()
        {
            string titulo = "Título de Teste";
            string mensagem = "";
            TipoNotificacao tipoNotificacao = TipoNotificacao.Usuario;
            Usuario destino = new Usuario();

            Assert.Throws<ArgumentNullException>(() =>
            {
                Notificacao notificacao = new Notificacao();
                notificacao.CriarNotificacao(titulo, mensagem, tipoNotificacao, destino);
            });
        }
    }
}
