using API.Data.Context;
using API.Domain.Interfaces;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CadastroDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                              .Include(f => f.fornecedor)
                              .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutoPorFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                  .Include(f => f.fornecedor)
                  .OrderBy(rr => rr.Nome)
                  .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

    }
}
