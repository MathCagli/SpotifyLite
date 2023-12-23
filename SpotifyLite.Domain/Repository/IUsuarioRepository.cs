using SpotifyLite.CrossCutting.Repository;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Models.Conta.Agreggates;

namespace SpotifyLite.Domain.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
    }
}
