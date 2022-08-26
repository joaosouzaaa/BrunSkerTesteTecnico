using BrunSker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrunSker.Infra.Contexts
{
    public class BrunSkerDbContext : DbContext
    {
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public BrunSkerDbContext(DbContextOptions<BrunSkerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrunSkerDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType()
                    .GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;

                else if (entry.State == EntityState.Modified)
                    entry.Property("RegistrationDate").IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
