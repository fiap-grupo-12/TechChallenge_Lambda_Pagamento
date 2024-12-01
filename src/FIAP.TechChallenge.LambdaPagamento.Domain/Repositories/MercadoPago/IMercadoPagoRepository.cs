using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago
{
    public interface IMercadoPagoRepository
    {
        Task<string> GetAccessToken();

        Task<string> GetQrCode(string idPedido, double valorTotal);

        Task<MercadoPagoOrderStatus> ObterStatusPedido(long id);
    }
}
