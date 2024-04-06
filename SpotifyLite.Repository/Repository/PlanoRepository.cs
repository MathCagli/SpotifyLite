using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;

namespace SpotifyLite.Repository.Repository
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        public PlanoRepository(SpotifyLiteContext context) : base(context)
        {
        }
    }
}
