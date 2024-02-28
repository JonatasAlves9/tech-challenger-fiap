namespace Application.DTOs;

public class CategoryDto
{
    public class CreateCategory
    {
        public string Name { get; set; }
    }

    public class UpdateCategory
    {
        public Guid id { get; set; }
        public string Name { get; set; }
    }
}