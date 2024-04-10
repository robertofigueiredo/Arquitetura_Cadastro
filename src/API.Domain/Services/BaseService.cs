using API.Domain.Interfaces;
using API.Domain.Models;
using API.Domain.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace API.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors) 
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.ManipularNotificacao(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) 
            where TValidacao : AbstractValidator<TEntidade>
            where TEntidade : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
