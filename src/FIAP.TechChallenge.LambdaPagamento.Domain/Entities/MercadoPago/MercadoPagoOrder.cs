﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago
{
    public class MercadoPagoOrder
    {
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("notification_url")]
        public string NotificationUrl { get; set; }
        [JsonPropertyName("total_amount")]
        public double TotalAmount { get; set; }
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
        [JsonPropertyName("sponsor")]
        public Sponsor Sponsor { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("unit_price")]
        public double UnitPrice { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("unit_measure")]
        public string UnitMeasure { get; set; }
        [JsonPropertyName("total_amount")]
        public double TotalAmount { get; set; }
    }

    public class Sponsor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
