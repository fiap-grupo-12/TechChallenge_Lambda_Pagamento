using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    public class MercadoPagoQrCode
    {
        public string InStoreOrderId { get; set; }
        public string QrData { get; set; }
    }
}
