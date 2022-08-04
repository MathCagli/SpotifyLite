using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
        }

        public async Task<AlbumOutputDto> Criar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<Album>(dto);
            await this.albumRepository.Save(album);
            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> ListarTodos()
        {
            var album = await this.albumRepository.GetAll();
            return this.mapper.Map<List<AlbumOutputDto>>(album);
        }

        public async Task<AlbumOutputDto> BuscarPorID(string id)
        {
            var album = await this.albumRepository.Get(id);
            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<AlbumOutputDto> Atualizar(AlbumOutputDto dto)
        {
            var album = this.mapper.Map<Album>(dto);
            await this.albumRepository.Update(album);
            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<string> Remover(string id)
        {
            var album = await this.albumRepository.Get(id);
            await this.albumRepository.Delete(album);
            return id;
        }
    }
}