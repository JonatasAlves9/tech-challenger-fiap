using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class CreateQRCodeResponseViewModel
    {
        [JsonProperty("in_store_order_id")]
        public string? InStoreOrderId { get; set; }

        [JsonProperty("qr_data")]
        public string? QrData { get; set; }

    }
}
