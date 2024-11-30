using System.Text.Json.Serialization;

namespace FIAP.TechChallenge.LambdaPagamento.Application.Models.Response
{
    public class PagamentoResponse
    {
        public Guid Id { get; set; }
        public decimal ValorTotal { get; set; }
        public string StatusPagamento { get; set; }

        public string QrCode { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
