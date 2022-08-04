using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models;

namespace SpotifyLite.Repository.Mapping
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlist");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Foto).IsRequired();

            builder.HasMany(x => x.Musicas).WithMany(x => x.Playlists);
        }
    }
}
