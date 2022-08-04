using Microsoft.EntityFrameworkCore;
using SpotifyLite.Domain.Models;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;

namespace SpotifyLite.Repository.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
