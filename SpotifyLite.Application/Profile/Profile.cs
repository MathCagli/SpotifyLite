using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;

namespace SpotifyLite.Application.Profile
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            // Album
            CreateMap<Album, AlbumOutputDto>();
            CreateMap<AlbumInputDto, Album>();
            CreateMap<AlbumOutputDto, Album>();

            // Banda
            CreateMap<BandaInputDto, Banda>();
            CreateMap<Banda, BandaOutputDto>();
            CreateMap<BandaOutputDto, Banda>();

            // Música
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.ValorFormatado()));
            CreateMap<MusicaInputDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            // Playlist
            CreateMap<PlaylistInputDto, Playlist>();
            CreateMap<Playlist, PlaylistOutputDto>();

            // Usuário
            CreateMap<Usuario, UsuarioOutputDto>()
                .ForMember(x => x.Email, f => f.MapFrom(m => m.Email.Valor))
                .ForMember(x => x.Senha, f => f.MapFrom(m => m.Senha.Valor));
            CreateMap<UsuarioInputDto, Usuario>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email))
                .ForPath(x => x.Senha.Valor, f => f.MapFrom(m => m.Senha));
        }
    }
}