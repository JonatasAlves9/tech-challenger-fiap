using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class TagViewModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ImageUrl { get; private set; }

        public static TagViewModel ToResult(Tag tag)
            => new()
            {
                Id = tag.Id,
                Name = tag.Name,
                ImageUrl = tag.ImageUrl,
            };

        public static List<TagViewModel> ToResultList(IEnumerable<Tag> tags)
       => tags.Select(tag => new TagViewModel()
       {
           Id = tag.Id,
           Name = tag.Name,
           ImageUrl = tag.ImageUrl
       }).ToList();
    }
}
