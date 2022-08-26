using BrunSker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrunSker.Infra.EntitiesMapping
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable(nameof(Locacao));

            builder.HasKey(x => x.Id);

            builder.Property(l => l.Preco).HasColumnType("decimal(18, 2)")
                .HasColumnName("preco").IsRequired(true);

            builder.Property(l => l.EstaLocado).HasColumnType("bit(1)")
                .HasColumnName("esta_locado").IsRequired(true);

            builder.Property(l => l.RegistrationDate).HasColumnType("datetime")
                .HasColumnName("registration_date").IsRequired(true);
        }
    }
}
