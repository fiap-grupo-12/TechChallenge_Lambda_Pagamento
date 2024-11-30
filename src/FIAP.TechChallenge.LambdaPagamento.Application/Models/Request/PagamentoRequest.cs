using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.Models.Request
{
    public class PagamentoRequest
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("valorTotal")]
        public decimal ValorTotal { get; set; }
    }
}
