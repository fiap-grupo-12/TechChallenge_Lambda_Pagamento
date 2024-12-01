using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases.MercadoPago
{
    public class MercadoPagoObterStatusPagamentoUseCase : IMercadoPagoObterStatusPagamentoUseCase
    {
        private readonly IMercadoPagoRepository _mercadoPagoRepository;
        private readonly IMapper _mapper;

        public MercadoPagoObterStatusPagamentoUseCase(IMercadoPagoRepository mercadoPagoRepository, IMapper mapper)
        {
            _mercadoPagoRepository = mercadoPagoRepository;
            _mapper = mapper;
        }

        public async Task<MercadoPagoOrderStatusResponse> Execute(string id)
        {
            var idPagamento = long.Parse(id);

            var result = await _mercadoPagoRepository.ObterStatusPedido(idPagamento);

            return _mapper.Map<MercadoPagoOrderStatusResponse>(result);
        }
    }
}
