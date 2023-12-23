using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);
            await this.usuarioRepository.Save(usuario);
            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> ListarTodos()
        {
            var usuario = await this.usuarioRepository.GetAll();
            return this.mapper.Map<List<UsuarioOutputDto>>(usuario);
        }

        public async Task<UsuarioOutputDto> BuscarPorID(string id)
        {
            var usuario = await this.usuarioRepository.Get(id);
            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioOutputDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);
            await this.usuarioRepository.Update(usuario);
            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<string> Remover(string id)
        {
            var usuario = await this.usuarioRepository.Get(id);
            await this.usuarioRepository.Delete(usuario);
            return id;
        }
    }
}