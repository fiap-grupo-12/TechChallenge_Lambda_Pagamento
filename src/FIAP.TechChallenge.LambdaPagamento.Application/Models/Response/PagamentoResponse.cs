using System.Text.Json.Serialization;

namespace FIAP.TechChallenge.LambdaPagamento.Application.Models.Response
{
    public class PagamentoResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("valorTotal")]
        public decimal ValorTotal { get; set; }

        [JsonPropertyName("statusPagamento")]
        public string StatusPagamento { get; set; }

        [JsonPropertyName("qrCode")]
        public string QrCode { get; set; }

        [JsonPropertyName("dataCriacao")]
        public string DataCriacao { get; set; }
    }
}
