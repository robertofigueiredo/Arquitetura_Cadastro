using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class DbContextAPI : DbContext
    {
        public DbContextAPI(DbContextOptions<DbContextAPI> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Com base nas Entidades, ele seta nvarchar 100 caso você não tenha fornecido na criação do Mapeamento da Tabela
            foreach (var propriedades in modelBuilder.Model.GetEntityTypes()
                                                           .SelectMany(rr => rr.GetProperties()
                                                           .Where(rr => rr.ClrType == typeof(string))))
                propriedades.SetColumnType("nvarchar(100)");

            //Para a inicialização, pega todas as entitidades que estão dentro do assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextAPI).Assembly);


            //"Varre" todos os relacionamento de chave estrangeira e seta para nulo, isso impede Delete em cascata
            // Onde 1 fornecedor pode ter 100 produtos
            foreach (var relationship in modelBuilder.Model
                                                     .GetEntityTypes()
                                                     .SelectMany(rr => rr.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
