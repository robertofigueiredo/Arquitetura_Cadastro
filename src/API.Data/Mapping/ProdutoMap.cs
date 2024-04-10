using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("nvarchar(200)");

            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasColumnType("nvarchar(1000)");

            builder.ToTable("Produtos_Tres_Camadas");
        }
    }
}
