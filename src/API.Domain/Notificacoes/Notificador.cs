using API.Domain.Interfaces;

namespace API.Domain.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacao;

        public Notificador()
        {
            _notificacao = new List<Notificacao>();
        }

        public void ManipularNotificacao(Notificacao notificacao)
        {
           _notificacao.Add(notificacao);   
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacao;
        }

        public bool TemNotificacao()
        {
            return _notificacao.Any();
        }
    }
}
