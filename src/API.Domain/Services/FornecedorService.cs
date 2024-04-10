using API.Domain.Interfaces;
using API.Domain.Models;
using API.Domain.Models.Validations;

namespace API.Domain.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _FornecedorRepository;

        public FornecedorService(IFornecedorRepository FornecedorRepository, INotificador notificador) : base(notificador)
        {
            _FornecedorRepository = FornecedorRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if(_FornecedorRepository.Buscar(rr => rr.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com o documento informado");
                return;
            }

            await _FornecedorRepository.Adicionar(fornecedor);
        }
        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_FornecedorRepository.Buscar(rr => rr.Documento == fornecedor.Documento && rr.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com o documento informado");
                return;
            }
            await _FornecedorRepository.Atualizar(fornecedor);
        }
        public async Task Remover(Guid id)
        {
            var fornecedor = await _FornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if(fornecedor is null)
            {
                Notificar("Fornecedor não existe!");
                return;
            }

            if(fornecedor.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados");
                return;
            }

            var endereco = await _FornecedorRepository.ObterEnderecoPorFornecedor(id);
            if(endereco is not null)
            {
                await _FornecedorRepository.RemoveEnderecoFornecedor(endereco);
            }
            await _FornecedorRepository.Remover(id);
        }
        public void Dispose()
        {
            _FornecedorRepository?.Dispose(); // tira da memória
        }

    }
}
