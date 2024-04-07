using SpotifyLite.Domain.Models.Core.ValueObject;
using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Models.Transacao.Agreggates;
using SpotifyLite.Domain.Models.Transacao.ValueObject;
using System.Security.Cryptography;
using System.Text;

namespace SpotifyLite.Domain.Models.Conta.Agreggates
{
    public class Usuario
    {

        private const string NOME_PLAYLIST = "Favoritas";

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtNascimento { get; set; }

        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
        public virtual IList<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Notificacao>();


        public void CriarConta(string nome, string email, string senha, DateTime dtNascimento, Plano plano, Cartao cartao)
        {
            Nome = nome;
            Email = email;
            DtNascimento = dtNascimento;

            //Criptografar a senha
            Senha = CriptografarSenha(senha);

            //Assinar um plano
            AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            AdicionarCartao(cartao);

            //Criar a playlist padrão do usuario
            CriarPlaylist(nome: NOME_PLAYLIST, publica: false);
        }

        public void CriarPlaylist(string nome, bool publica = true)
        {
            Playlists.Add(new Playlist()
            {
                Nome = nome,
                Publica = publica,
                DtCriacao = DateTime.Now,
                Usuario = this
            });
        }

        private void AdicionarCartao(Cartao cartao)
            => Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            Assinaturas.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DtAtivacao = DateTime.Now,
            });

        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (Assinaturas.Count > 0 && Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        private string CriptografarSenha(string senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();
            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta);
            var criptoResult = criptoProvider.ComputeHash(btexto);
            return Convert.ToHexString(criptoResult);
        }
    }
}
