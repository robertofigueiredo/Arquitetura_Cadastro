using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor_Tres_Camadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor_Tres_Camadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco_Tres_Camadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco_Tres_Camadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Tres_Camadas_Fornecedor_Tres_Camadas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor_Tres_Camadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos_Tres_Camadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos_Tres_Camadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Tres_Camadas_Fornecedor_Tres_Camadas_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor_Tres_Camadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Tres_Camadas_FornecedorId",
                table: "Endereco_Tres_Camadas",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Tres_Camadas_FornecedorId",
                table: "Produtos_Tres_Camadas",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco_Tres_Camadas");

            migrationBuilder.DropTable(
                name: "Produtos_Tres_Camadas");

            migrationBuilder.DropTable(
                name: "Fornecedor_Tres_Camadas");
        }
    }
}
