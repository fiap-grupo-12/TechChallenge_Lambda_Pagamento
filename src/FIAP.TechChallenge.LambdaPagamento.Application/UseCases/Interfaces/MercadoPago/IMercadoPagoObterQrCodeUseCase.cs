using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago
{
    public interface IMercadoPagoObterQrCodeUseCase : IUseCaseAsync<MercadoPagoOrderRequest, string>
    {
    }
}
