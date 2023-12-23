using SpotifyLite.Domain.Models.Transacao.Agreggates;

namespace SpotifyLite.Tests.Domain
{
    public class CartaoDomainTests
    {

        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
            };

            var merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            cartao.CriarTransacao(merchant, 19M, "Dummy Transacao");
            Assert.True(cartao.Transacoes.Count > 0);
            Assert.True(cartao.Limite == 981M);

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1000M,
                Numero = "6465465466",
            };

            var merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoSemLimite()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 10M,
                Numero = "6465465466",
            };

            var merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoValorDuplicado()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
            };

            cartao.Transacoes.Add(new SpotifyLite.Domain.Models.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            var merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoAltoFrequencia()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
            };

            cartao.Transacoes.Add(new SpotifyLite.Domain.Models.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            cartao.Transacoes.Add(new SpotifyLite.Domain.Models.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            cartao.Transacoes.Add(new SpotifyLite.Domain.Models.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });


            var merchant = new SpotifyLite.Domain.Models.Transacao.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }
    }
}
