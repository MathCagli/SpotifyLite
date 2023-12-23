﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models.Conta.Agreggates;

namespace SpotifyLite.Repository.Mapping.Conta
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable(nameof(Playlist));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Publica).IsRequired();
            builder.Property(x => x.DtCriacao).IsRequired();

            builder.HasMany(x => x.Musicas).WithMany(x => x.Playlists);


        }
    }
}
