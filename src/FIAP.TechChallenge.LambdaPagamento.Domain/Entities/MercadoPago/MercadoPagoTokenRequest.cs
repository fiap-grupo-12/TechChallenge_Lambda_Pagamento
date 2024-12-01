using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    [ExcludeFromCodeCoverage]
    public class MercadoPagoToken
    {
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }
    }
}
