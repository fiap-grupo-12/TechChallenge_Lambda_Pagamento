using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases
{
    public class CriarPagamentoUseCase(
        IPagamentoRepository pagamentoRepository,
        IMapper mapper
        ) : ICriarPagamentoUseCase
    {

        private readonly IPagamentoRepository _pagamentoRepository = pagamentoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagamentoResponse> Execute(PagamentoRequest request)
        {
            var pagamento = new Pagamento()
            {
                Id = request.Id,
                ValorTotal = request.ValorTotal,
                DataCriacao = DateTime.Now,
                StatusPagamento = StatusPagamento.Pendente
            };

            var result = await _pagamentoRepository.Post(pagamento);

            return _mapper.Map<PagamentoResponse>(result);
        }
    }
}
