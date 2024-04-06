using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IMapper mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            this.playlistRepository = playlistRepository;
            this.mapper = mapper;
        }

        public async Task<PlaylistDTO> Criar(PlaylistDTO dto)
        {
            var playlist = this.mapper.Map<Playlist>(dto);
            await this.playlistRepository.Save(playlist);
            return this.mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<List<PlaylistDTO>> ListarTodos()
        {
            var playlist = await this.playlistRepository.GetAll();
            return this.mapper.Map<List<PlaylistDTO>>(playlist);
        }

        public async Task<PlaylistDTO> BuscarPorID(string id)
        {
            var playlist = await this.playlistRepository.Get(new Guid(id));
            return this.mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<PlaylistDTO> Atualizar(PlaylistDTO dto)
        {
            var playlist = this.mapper.Map<Playlist>(dto);
            await this.playlistRepository.Update(playlist);
            return this.mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<string> Remover(string id)
        {
            var playlist = await this.playlistRepository.Get(new Guid(id));
            await this.playlistRepository.Delete(playlist);
            return id;
        }
    }
}