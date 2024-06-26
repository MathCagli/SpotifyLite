﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyLite.Domain.Models.Core.ValueObject;
using SpotifyLite.Domain.Models.Transacao.ValueObject;

namespace SpotifyLite.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<Domain.Models.Transacao.Agreggates.Transacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Transacao.Agreggates.Transacao> builder)
        {
            builder.ToTable(nameof(Domain.Models.Transacao.Agreggates.Transacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtTransacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Merchant>(d => d.Merchant, c =>
            {
                c.Property(x => x.Nome).HasColumnName("MerchantNome").IsRequired();
            });

            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).HasColumnName("ValorTransacao").IsRequired();
            });
        }
    }
}
