using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Tests.Mock
{
    public class MercadoPagoObterStatusPagamentoMock
    {
        public static MercadoPagoOrderStatus MercadoPagoOrderStatusResponseFake() => new MercadoPagoOrderStatus()
        {
            ExternalReference = Guid.NewGuid().ToString(),
            Id = 12345,
            Status = "closed"
        };
    }
}
