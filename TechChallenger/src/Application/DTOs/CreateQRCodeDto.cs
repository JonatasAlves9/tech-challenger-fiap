using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.MercadoPago;

namespace Application.DTOs
{
    public class CreateQRCodeDTO
    {
        public CashOutViewModel? CashOut { get; set; }
        public string? Description { get; set; }
        public string? ExternalReference { get; set; }
        public IEnumerable<ItemsDto>? Items { get; set; }
        public string? NotificationUrl { get; set; }
        public string? OrderId { get; set; }
        public string? Title { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
