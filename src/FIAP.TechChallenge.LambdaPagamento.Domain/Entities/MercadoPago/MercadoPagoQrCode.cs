using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    [ExcludeFromCodeCoverage]
    public class MercadoPagoQrCode
    {
        public string InStoreOrderId { get; set; }
        public string QrData { get; set; }
    }
}
