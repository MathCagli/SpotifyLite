using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models;

namespace SpotifyLite.Repository.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired().HasMaxLength(1024);
            });
            builder.OwnsOne(x => x.Senha, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Senha").IsRequired();
            });
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(1);

            builder.HasMany(x => x.Playlists).WithOne();
        }
    }
}