using Amazon.DynamoDBv2.DataModel;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    [DynamoDBTable("PagamentoTable")]
    public class Pagamento
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }

        [DynamoDBHashKey("valorTotal")]
        public decimal ValorTotal { get; set; }

        [DynamoDBHashKey("statusPagamento")]
        public StatusPagamento StatusPagamento { get; set; }

        [DynamoDBHashKey("qrCode")]
        public string QrCode { get; set; }

        [DynamoDBHashKey("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }
}
