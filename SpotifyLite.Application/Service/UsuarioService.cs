using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Models.Transacao.Agreggates;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IPlanoRepository planoRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPlanoRepository planoRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.planoRepository = planoRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioDTO> Criar(UsuarioDTO dto)
        {
            if (this.usuarioRepository.Exists(x => x.Email == dto.Email))
                throw new Exception("Usuario já existente na base");


            Plano plano = this.planoRepository.Get(dto.PlanoId).Result;

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao cartao = this.mapper.Map<Cartao>(dto.Cartao);

            Usuario usuario = new Usuario();
            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DtNascimento, plano, cartao);

            this.usuarioRepository.Save(usuario);
            var result = this.mapper.Map<UsuarioDTO>(usuario);

            return result;
        }

        public async Task<List<UsuarioDTO>> ListarTodos()
        {
            var usuario = await this.usuarioRepository.GetAll();
            return this.mapper.Map<List<UsuarioDTO>>(usuario);
        }

        public async Task<UsuarioDTO> BuscarPorID(string id)
        {
            var usuario = await this.usuarioRepository.Get(new Guid(id));
            return this.mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> Atualizar(UsuarioDTO dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);
            await this.usuarioRepository.Update(usuario);
            return this.mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<string> Remover(string id)
        {
            var usuario = await this.usuarioRepository.Get(new Guid(id));
            await this.usuarioRepository.Delete(usuario);
            return id;
        }
    }
}