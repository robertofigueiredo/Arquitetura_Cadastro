
using API.Data.Context;
using API.Domain.Interfaces;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace API.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CadastroDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedor.AsNoTracking()
                              .Include(e => e.Endereco)
                              .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedor.AsNoTracking()
                              .Include(e => e.Endereco)
                              .Include(p => p.Produtos)
                              .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        { 
            return await Db.Endereco.AsNoTracking()
                                    .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }

        public async Task RemoveEnderecoFornecedor(Endereco endereco)
        {
            Db.Endereco.Remove(endereco);
            await SaveChanges();
        }
    }
}
