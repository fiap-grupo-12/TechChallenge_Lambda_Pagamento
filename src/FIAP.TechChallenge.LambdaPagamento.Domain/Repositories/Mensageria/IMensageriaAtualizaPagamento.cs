using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.Mensageria
{
    public interface IMensageriaAtualizaPagamento
    {
        Task SendMessage(string body);
    }
}
