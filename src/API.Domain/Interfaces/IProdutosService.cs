using API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Interfaces
{
    public interface IProdutosService
    {
        Task AdicionarProduto(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
