using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    [ExcludeFromCodeCoverage]
    public class MercadoPagoSettings
    {
        public string NotificationUrl { get; set; }
        public long UserId { get; set; }
        public string PosId { get; set; }
        public string AccessToken { get; set; }
    }
}
