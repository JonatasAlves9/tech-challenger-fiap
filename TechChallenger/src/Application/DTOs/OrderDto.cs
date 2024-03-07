namespace Application.DTOs;

public class OrderDto
{
    public class CreateOrder
    {
        public Guid CustomerId { get; set; }
        public double Discount { get; set; }
    }

    public class UpdateOrder
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public double Discount { get; set; }
    }
}