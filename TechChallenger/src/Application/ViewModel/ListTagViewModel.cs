using Domain.Entities;

namespace Application.ViewModel
{
    public class ListTagViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }

        public static List<ListTagViewModel> ToResult(List<Tag> tags)
            => tags.Select(tag => new ListTagViewModel()
            {
                Id = tag.Id,
                Name = tag.Name,
                ImageUrl = tag.ImageUrl,
            }).ToList();

    }
}
