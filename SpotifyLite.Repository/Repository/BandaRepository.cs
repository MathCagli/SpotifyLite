using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;

namespace SpotifyLite.Repository.Repository
{
    public class BandaRepository : Repository<Banda>, IBandaRepository
    {
        public BandaRepository(SpotifyLiteContext context) : base(context)
        {
        }
    }
}
