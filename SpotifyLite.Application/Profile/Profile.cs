using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Models.Conta.Agreggates;

namespace SpotifyLite.Application.Profile
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            // Playlist
            CreateMap<Playlist, PlaylistInputDto>().ReverseMap();
            CreateMap<Playlist, PlaylistOutputDto>().ReverseMap();

            // Usuário
            CreateMap<UsuarioInputDto, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioOutputDto>().ReverseMap();
        }
    }
}