using System.Collections.Generic;
using DesafioSidequest.Business.Notificacoes;

namespace DesafioSidequest.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}