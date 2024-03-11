using Application.DTOs;
using Application.ViewModel.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Interfaces
{
    public interface IPaymentUseCase
    {
        object CreateQRCode(CreateQRCodeDTO data);
        bool PayingOrder(ReceiptViewModel data, Guid orderId);
    }
}
