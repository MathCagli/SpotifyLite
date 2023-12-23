using SpotifyLite.CrossCutting.Repository;
using SpotifyLite.Domain.Models.Conta.Agreggates;

namespace SpotifyLite.Domain.Repository
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
    }
}
