using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class CreateQRCodeResponseViewModel
    {
        public string? InStoreOrderId { get; set; }
        public string? QrData { get; set; }

    }
}
