namespace Application.DTOs;

public class TagDto
{
    public class CreateTag
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class UpdateTag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}