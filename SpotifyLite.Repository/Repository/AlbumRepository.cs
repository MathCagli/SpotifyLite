using SpotifyLite.Domain.Models.Streaming.Agreggates;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;

namespace SpotifyLite.Repository.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyLiteContext context) : base(context)
        {
        }
    }
}
