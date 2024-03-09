using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.MercadoPago;
using Newtonsoft.Json;

namespace Application.DTOs
{

    public class CreateQRCodeDTO
    {

        [JsonProperty("cash_out")]
        public CashOutViewModel? CashOut { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("external_reference")]
        public string? ExternalReference { get; set; }

        [JsonProperty("items")]
        public IEnumerable<ItemsDto>? Items { get; set; }

        [JsonProperty("notification_url")]
        public string? NotificationUrl { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonIgnore]
        public Guid OrderId { get; set; }

    }
}
