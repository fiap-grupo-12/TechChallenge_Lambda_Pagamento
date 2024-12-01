using Amazon.SQS;
using Amazon.SQS.Model;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.Mensageria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories.Mensageria
{
    public class MensageriaAtualizaPagamento : IMensageriaAtualizaPagamento
    {
        private readonly IAmazonSQS _amazonSQS;
        private readonly string _url;

        public MensageriaAtualizaPagamento(IAmazonSQS amazonSQS)
        {
            _amazonSQS = amazonSQS;
            _url = Environment.GetEnvironmentVariable("url_sqs_atualiza_pagamento_pedido");
        }

        public async Task SendMessage(string body)
        {
            var message = new SendMessageRequest()
            {
                QueueUrl = _url,
                MessageBody = body
            };
            try
            {
                await _amazonSQS.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar a mensagem: {ex}");
            }
        }
    }
}
