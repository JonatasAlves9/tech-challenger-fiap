using Application.DTOs;
using Application.UseCases.Interfaces;
using Application.ViewModel.MercadoPago;
using Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public PaymentUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public object CreateQRCode(CreateQRCodeDTO data)
        {
            string url = $"https://api.mercadopago.com/instore/orders/qr/seller/collectors/{Environment.GetEnvironmentVariable("MP_USER_ID")}/pos/{Environment.GetEnvironmentVariable("MP_POS_ID")}/qrs";

            data.NotificationUrl = $"{Environment.GetEnvironmentVariable("MP_URL")}Payment/Receipt?orderId={data.OrderId}";

            string json = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Environment.GetEnvironmentVariable("MP_TOKEN"));
                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.DeserializeObject<CreateQRCodeResponseViewModel>(response.Content.ReadAsStringAsync().Result);

                        return result;
                    }
                    else
                    {
                        throw new Exception("Erro ao realizar a integração: " + response.RequestMessage);
                    }
                }
                catch (Exception ex)
                {
                    return new Exception(ex.Message);
                }
            }
        }

        public object PayingOrder(ReceiptViewModel data, Guid? orderId)
        {
            try
            {
                if(data.Collection?.Status?.ToLower() != "approved")
                {
                    return new
                    {
                        Sucess = true,
                        Message = "Notification received"
                    };
                }

                if(orderId == null)
                {
                    return new
                    {
                        Sucess = true,
                        Message = "Notification received: OrderId cannot be null! "
                    };
                }

                var order = _orderRepository.GetByIdAsync((Guid)orderId).Result;

                order.MoveToNextStep();

                _orderRepository.Update(order);

                return new
                {
                    Sucess = true,
                    Message = "Payment made"
                };
            }
            catch (Exception ex)
            {

                return new Exception(ex.Message);
            }
        }
    }
}
