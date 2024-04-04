using API.Domain.Models.Validations.Documentos;
using FluentValidation;

namespace API.Domain.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(rr => rr.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(rr => rr.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(rr => rr.Documento.Length).Equal(ValidacaoDocs.CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(rr => ValidacaoDocs.CpfValidacao.Validar(rr.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });

            When(rr => rr.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(rr => rr.Documento.Length).Equal(ValidacaoDocs.CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(rr => ValidacaoDocs.CnpjValidacao.Validar(rr.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });
        }
    }
}
