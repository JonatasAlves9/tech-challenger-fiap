using System.Text;
using Application.DTOs;
using Application.UseCases.Interfaces;
using Application.ViewModel.MercadoPago;
using Domain.Repositories;
using Newtonsoft.Json;

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

            data.NotificationUrl = $"{Environment.GetEnvironmentVariable("URL_API")}Payment/Receipt?orderId={data.OrderId}";

            string json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Environment.GetEnvironmentVariable("MP_TOKEN"));
                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = new CreateQRCodeResponseViewModel();
                        JsonConvert.PopulateObject(response.Content.ReadAsStringAsync().Result, result);

                        return result;
                    }
                    else
                    {
                        throw new Exception("Error performing integration:: " + response.RequestMessage);
                    }
                }
                catch (Exception ex)
                {
                    return new Exception(ex.Message);
                }
            }
        }

        public bool PayingOrder(ReceiptViewModel data, Guid orderId)
        {
            try
            {
                var order = _orderRepository.GetByIdAsync(orderId).Result;

                if (order == null)
                    throw new Exception("Order not found!");
                
                order.MarkAsPaid();

                _orderRepository.Update(order);

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
