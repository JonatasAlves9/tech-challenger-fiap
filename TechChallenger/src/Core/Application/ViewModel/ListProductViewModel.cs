using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ListProductViewModel
    {
        public string Name { get; private set; }
        public Guid CategoryId { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int Estimative { get; private set; }

        public static List<ListProductViewModel> ToResult(IEnumerable<Product> products)
            => products.Select(product => new ListProductViewModel()
            {
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Estimative = product.Estimative,
            }).ToList();

    }
}
