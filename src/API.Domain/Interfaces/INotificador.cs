using API.Domain.Notificacoes;

namespace API.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void ManipularNotificacao(Notificacao notificacao);
    }
}
