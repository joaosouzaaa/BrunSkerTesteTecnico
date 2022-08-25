using BrunSker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrunSker.Infra.EntitiesMapping
{
    public class LeaseMapping : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.ToTable(nameof(Lease));

            builder.HasKey(x => x.Id);

            builder.Property(l => l.Price).HasColumnType("decimal(18, 2)")
                .HasColumnName("price").IsRequired(true);

            builder.Property(l => l.IsRented).HasColumnType("bit(1)")
                .HasColumnName("is_rented").IsRequired(true);

            builder.Property(l => l.RegistrationDate).HasColumnType("datetime")
                .HasColumnName("registration_date").IsRequired(true);

            builder.HasOne(l => l.Address)
                .WithOne(a => a.Lease)
                .HasForeignKey<Lease>(l => l.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
