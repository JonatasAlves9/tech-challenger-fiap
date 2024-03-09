using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class CashOutViewModel
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
