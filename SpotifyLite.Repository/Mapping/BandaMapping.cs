using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models;

namespace SpotifyLite.Repository.Mapping
{
    public class BandaMapping : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable("Banda");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Foto).IsRequired();

            builder.HasMany(x => x.Albuns).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
