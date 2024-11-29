﻿using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;


namespace FIAP.TechChallenge.LambdaPagamento.Tests.Mock
{
    public class PagamentoRequestMock
    {
        public static Pagamento PagamentoFake() => new Pagamento()
        {
            Id = Guid.NewGuid(),
            ValorTotal = 50,
            DataCriacao = DateTime.Now,
            StatusPagamento = StatusPagamento.Pendente
        };

        public static PagamentoRequest PagamentoRequestFake() => new PagamentoRequest()
        {
            Id = Guid.NewGuid(),
            ValorTotal = 50
        };
    }
}
