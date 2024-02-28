namespace Application.ViewModel;

public class ProductDto
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Estimative { get; set; }   
    }

    public class UpdateProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Estimative { get; set; }
    }
}