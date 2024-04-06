using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Transacao.Agreggates;

namespace SpotifyLite.Application.Profile
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            // Playlist
            CreateMap<Playlist, PlaylistDTO>().ReverseMap();

            // Usuário
            CreateMap<Usuario, UsuarioDTO>().AfterMap((s, d) =>
            {
                var plano = s.Assinaturas?.FirstOrDefault(a => a.Ativo)?.Plano;
                if (plano != null)
                    d.PlanoId = plano.Id;
                d.Senha = "xxxxxxxxx";
            }).ReverseMap();

            // Cartão
            CreateMap<CartaoDTO, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite))
                .ReverseMap();
        }
    }
}