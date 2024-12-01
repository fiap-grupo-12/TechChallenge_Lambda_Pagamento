using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago.MercadoPagoOrder;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases.MercadoPago
{
    public class MercadoPagoObterQrCodeUseCase : IMercadoPagoObterQrCodeUseCase
    {
        private readonly IMercadoPagoRepository _mercadoPagoRepository;
        private readonly IMapper _mapper;

        public MercadoPagoObterQrCodeUseCase(IMercadoPagoRepository mercadoPagoRepository, IMapper mapper)
        {
            _mercadoPagoRepository = mercadoPagoRepository;
            _mapper = mapper;
        }


        public async Task<string> Execute(MercadoPagoOrderRequest request)
        {
            var item = new Item
            {
                Title = "Item",
                Description = "Descricao do Produto",
                UnitPrice = request.Valor,
                Quantity = 1,
                UnitMeasure = "unit",
                TotalAmount = request.Valor
            };



            var orderRequest = new MercadoPagoOrder
            {
                ExternalReference = request.IdPedido.ToString(),
                Title = "Pedido ByteMeBurguer",
                Description = "Novo Pedido",
                NotificationUrl = "https://webhook.site/ae613572-32fa-42f9-bdc1-e7ba88cb69fa",
                TotalAmount = request.Valor,
                Items = new List<Item> { item },
                Sponsor = new Sponsor
                {
                    Id = 64160023
                }
            };

            var result = await _mercadoPagoRepository.GetQrCode(request.IdPedido.ToString(), request.Valor);

            return result;
        }
    }
}
