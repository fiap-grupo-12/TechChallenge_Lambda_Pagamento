using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.Models.Request.MercadoPago
{
    public class MercadoPagoOrderRequest
    {
        [JsonPropertyName("idPedido")]
        public Guid IdPedido { get; set; }

        [JsonPropertyName("valor")]
        public double Valor { get; set; }
    }
}
