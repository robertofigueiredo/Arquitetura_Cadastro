using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Logradouro)
                   .IsRequired()
                   .HasColumnType("nvarchar(200)");

            builder.Property(f => f.Numero)
                   .IsRequired()
                   .HasColumnType("nvarchar(50)");

            builder.Property(f => f.Cep)
                   .IsRequired()
                   .HasColumnType("nvarchar(8)");

            builder.Property(f => f.Complemento)
                   .IsRequired()
                   .HasColumnType("nvarchar(250)");

            builder.Property(f => f.Bairro)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            builder.Property(f => f.Cidade)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            builder.Property(f => f.Estado)
                   .IsRequired()
                   .HasColumnType("nvarchar(50)");

            builder.ToTable("Endereco_Tres_Camadas");
        }
    }
}
