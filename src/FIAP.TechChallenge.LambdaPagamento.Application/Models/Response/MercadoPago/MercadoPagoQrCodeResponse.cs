using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago
{
    public class MercadoPagoQrCodeResponse
    {
        [JsonPropertyName("in_store_order_id")]
        public string InStoreOrderId { get; set; }
        [JsonPropertyName("qr_data")]
        public string QrData { get; set; }
    }
}
