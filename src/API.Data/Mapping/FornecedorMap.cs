using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                   .IsRequired()
                   .HasColumnType("nvarchar(200)");

            builder.Property(f => f.Documento)
                   .IsRequired()
                   .HasColumnType("nvarchar(14)");
            
            // Relation 1:1 Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                   .WithOne(e => e.fornecedor);

            // Relation 1:1 Fornecedor : Produto
            builder.HasMany(f => f.Produtos)
                   .WithOne(p => p.fornecedor)
                   .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedor_Tres_Camadas");
        }
    }
}
