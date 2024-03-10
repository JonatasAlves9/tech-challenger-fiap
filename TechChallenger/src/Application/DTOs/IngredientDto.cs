namespace Application.DTOs;

public class IngredientDto
{
    public class CreateIngredient
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class UpdateIngredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}