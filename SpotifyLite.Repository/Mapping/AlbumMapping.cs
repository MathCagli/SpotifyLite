using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models;

namespace SpotifyLite.Repository.Mapping
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DataLancamento).IsRequired();
            builder.Property(x => x.Capa);

            builder.HasMany(x => x.Musicas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}