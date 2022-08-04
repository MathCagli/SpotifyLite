using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class MusicaService : IMusicaService
    {
        private readonly IMusicaRepository musicaRepository;
        private readonly IMapper mapper;

        public MusicaService(IMusicaRepository musicaRepository, IMapper mapper)
        {
            this.musicaRepository = musicaRepository;
            this.mapper = mapper;
        }

        public async Task<MusicaOutputDto> Criar(MusicaInputDto dto)
        {
            var musica = this.mapper.Map<Musica>(dto);
            await this.musicaRepository.Save(musica);
            return this.mapper.Map<MusicaOutputDto>(musica);
        }

        public async Task<List<MusicaOutputDto>> ListarTodos()
        {
            var musica = await this.musicaRepository.GetAll();
            return this.mapper.Map<List<MusicaOutputDto>>(musica);
        }

        public async Task<MusicaOutputDto> BuscarPorID(string id)
        {
            var musica = await this.musicaRepository.Get(id);
            return this.mapper.Map<MusicaOutputDto>(musica);
        }

        public async Task<MusicaOutputDto> Atualizar(MusicaOutputDto dto)
        {
            var musica = this.mapper.Map<Musica>(dto);
            await this.musicaRepository.Update(musica);
            return this.mapper.Map<MusicaOutputDto>(musica);
        }

        public async Task<string> Remover(string id)
        {
            var musica = await this.musicaRepository.Get(id);
            await this.musicaRepository.Delete(musica);
            return id;
        }
    }
}