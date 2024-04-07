using AutoMapper;
using SpotifyLite.Application.DTO;
using SpotifyLite.Domain.Repository;

namespace SpotifyLite.Application.Service
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository planoRepository;
        private readonly IMapper mapper;

        public PlanoService(IPlanoRepository planoRepository, IMapper mapper)
        {
            this.planoRepository = planoRepository;
            this.mapper = mapper;
        }

        public async Task<List<PlanoDTO>> ListarTodos()
        {
            var plano = await this.planoRepository.GetAll();
            return this.mapper.Map<List<PlanoDTO>>(plano);
        }
    }
}