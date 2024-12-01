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

        [DynamoDBProperty("valorTotal")]
        public double ValorTotal { get; set; }

        [DynamoDBProperty("statusPagamento")]
        public StatusPagamento StatusPagamento { get; set; }

        [DynamoDBProperty("qrCode")]
        public string QrCode { get; set; }

        [DynamoDBProperty("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }
}
