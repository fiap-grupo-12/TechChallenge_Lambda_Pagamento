using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.Mensageria;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using Newtonsoft.Json;
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
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMensageriaAtualizaPagamento _mensageria;
        private readonly IMapper _mapper;

        public MercadoPagoObterStatusPagamentoUseCase(
            IMercadoPagoRepository mercadoPagoRepository,
            IPagamentoRepository pagamentoRepository,
            IMensageriaAtualizaPagamento mensageria,
            IMapper mapper
            )
        {
            _mercadoPagoRepository = mercadoPagoRepository;
            _pagamentoRepository = pagamentoRepository;
            _mensageria = mensageria;
            _mapper = mapper;
        }

        public async Task<MercadoPagoOrderStatusResponse> Execute(string id)
        {
            var idPagamento = long.Parse(id);

            var result = await _mercadoPagoRepository.ObterStatusPedido(idPagamento);

            var pagamento = await _pagamentoRepository.GetById(Guid.Parse(result.ExternalReference));

            if (pagamento == null)
                return null;

            if (result.Status == "closed")
                pagamento.StatusPagamento = Domain.Entities.Enum.StatusPagamento.Aprovado;
            else if (result.Status == "expired")
                pagamento.StatusPagamento = Domain.Entities.Enum.StatusPagamento.Recusado;

            await _pagamentoRepository.Update(pagamento, pagamento.Id);

            await _mensageria.SendMessage(JsonConvert.SerializeObject(new
            {
                idPedido = pagamento.Id,
                qrcode = pagamento.QrCode,
                statusPagamento = pagamento.StatusPagamento
            }));

            return _mapper.Map<MercadoPagoOrderStatusResponse>(result);
        }
    }
}
