using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    public class MercadoPagoOrderStatus
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }
    }
}
