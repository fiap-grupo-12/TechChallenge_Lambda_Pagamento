using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using Amazon.DynamoDBv2.Model;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request.MercadoPago;

namespace FIAP.TechChallenge.LambdaPagamento.Tests.Mock
{
    public class MercadoPagoOrderRequestMock
    {
        public static MercadoPagoOrderRequest MercadoPagoOrderRequestFake() => new MercadoPagoOrderRequest()
        {
            IdPedido = Guid.NewGuid(),
            Valor = 100.00
        };
        

        public static MercadoPagoQrCode MercadoPagoQrCodeResponseFake() => new MercadoPagoQrCode()
        {
            QrData = "00020101021226940014BR.GOV.BCB.PIX2572pix-qr.mercadopago.com/instore/o/v2/4892dc61-292c-453b-9e5b-4fa0c06b5e665204000053039865802BR59166009SAO PAULO62070503***630492EE",
            InStoreOrderId = Guid.NewGuid().ToString()
        };
    }
}
