using BrunSker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrunSker.Infra.EntitiesMapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(nameof(Endereco));

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Cep).HasColumnType("char(9)")
                .HasColumnName("cep").IsRequired(true);

            builder.Property(a => a.Logradouro).HasColumnType("varchar(50)")
                .HasColumnName("logradouro").IsRequired(true);

            builder.Property(a => a.Complemento).HasColumnType("varchar(50)")
                .HasColumnName("complemento").IsRequired(false);

            builder.Property(a => a.Bairro).HasColumnType("varchar(50)")
                .HasColumnName("bairro").IsRequired(true);

            builder.Property(a => a.Localidade).HasColumnType("varchar(50)")
                .HasColumnName("localidade").IsRequired(true);

            builder.Property(a => a.Uf).HasColumnType("char(2)")
                .HasColumnName("uf").IsRequired(true);

            builder.Property(a => a.Ibge).HasColumnType("char(7)")
                .HasColumnName("ibge").IsRequired(true);

            builder.Property(a => a.Gia).HasColumnType("char(4)")
                .HasColumnName("gia").IsRequired(false);

            builder.Property(a => a.Ddd).HasColumnType("char(2)")
                .HasColumnName("ddd").IsRequired(true);

            builder.Property(a => a.Siafi).HasColumnType("char(4)")
                .HasColumnName("siafi").IsRequired(true);

            builder.Property(a => a.RegistrationDate).HasColumnType("datetime")
                .HasColumnName("registration_date").IsRequired(true);

            builder.HasOne(a => a.Locacao)
                .WithOne(l => l.Endereco)
                .HasForeignKey<Endereco>(a => a.LocacaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
