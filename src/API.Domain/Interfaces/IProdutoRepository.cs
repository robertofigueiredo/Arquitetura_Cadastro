using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
