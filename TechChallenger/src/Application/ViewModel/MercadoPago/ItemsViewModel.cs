using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class ItemsViewModel
    {
        public string? SkuNumber { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? UnitMeasure { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
