﻿using SpotifyLite.Domain.Models.Conta.Agreggates;
using SpotifyLite.Domain.Repository;
using SpotifyLite.Repository.Context;

namespace SpotifyLite.Repository.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SpotifyLiteContext context) : base(context)
        {
        }
    }
}
