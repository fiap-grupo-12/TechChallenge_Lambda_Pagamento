using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories.MercadoPago
{
    public class MercadoPagoRepository : IMercadoPagoRepository
    {
        private readonly MercadoPagoSettings _mercadoPagoSettings;

        public MercadoPagoRepository(IOptions<MercadoPagoSettings> optionsMercadoPagoSettings)
        {
            _mercadoPagoSettings = optionsMercadoPagoSettings.Value;
        }

        public async Task<string> GetAccessToken()
        {
            var json = new MercadoPagoToken
            {
                ClientId = "6386144729389238",
                ClientSecret = "qoD6B1zXCfweUt6bBgnxZ2sZpp15706X",
                GrantType = "client_credentials"
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.mercadopago.com/oauth/token");
            request.Content = new StringContent(JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");

            using var response = await new HttpClient().SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var token = JsonSerializer.Deserialize<MercadoPagoTokenResponse>(await response.Content.ReadAsStringAsync());

                return token.AccessToken;
            }

            return string.Empty;
        }

        public async Task<string> GetQrCode(string idPedido, double valorTotal)
        {
            var accessToken = await GetAccessToken();

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/120099886/pos/FIAPGrupo12/qrs");
            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            var mercadoPagoOrder = MercadoPagoOrder.NewInstance(idPedido, valorTotal);
            var json = JsonSerializer.Serialize(mercadoPagoOrder);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await new HttpClient().SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var qrResponse = JsonSerializer.Deserialize<MercadoPagoQrCodeResponse>(await response.Content.ReadAsStringAsync());

                return qrResponse.QrData;
            }

            return string.Empty;
        }

        public async Task<MercadoPagoOrderStatus> ObterStatusPedido(long id)
        {
            var accessToken = await GetAccessToken();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.mercadopago.com/merchant_orders/{id}");
            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            using var response = await new HttpClient().SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var statusResponse = JsonSerializer.Deserialize<MercadoPagoOrderStatus>(await response.Content.ReadAsStringAsync());
                return statusResponse;
            }

            return null;
        }
    }
}
