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
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases
{
    public class CriarPagamentoUseCase(
        IPagamentoRepository pagamentoRepository,
        IMercadoPagoRepository mercadoPagoRepository,
        IMapper mapper
        ) : ICriarPagamentoUseCase
    {

        private readonly IPagamentoRepository _pagamentoRepository = pagamentoRepository;
        private readonly IMercadoPagoRepository _mercadoPagoRepository = mercadoPagoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PagamentoResponse> Execute(PagamentoRequest request)
        {
            var pagamento = new Pagamento
            {
                Id = request.Id,
                ValorTotal = request.ValorTotal,
                QrCode = await _mercadoPagoRepository.GetQrCode(request.Id.ToString(), request.ValorTotal),
                StatusPagamento = StatusPagamento.Pendente,
                DataCriacao = DateTime.Now,
            };

            var result = await _pagamentoRepository.Post(pagamento);

            return _mapper.Map<PagamentoResponse>(result);
        }
    }
}
