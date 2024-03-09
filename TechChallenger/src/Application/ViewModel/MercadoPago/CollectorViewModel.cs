using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MercadoPago
{
    public class CollectorViewModel
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public PhoneViewModel? Phone { get; set; }
        public IdentificationViewModel? Identification { get; set; }
        public string? Email { get; set; }
        public string? Nickname { get; set; }
    }
}
