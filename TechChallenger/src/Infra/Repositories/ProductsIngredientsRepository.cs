using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProductsIngredientsRepository : EfRepository<ProductsIngredients>, IProductsIngredientsRepository
    {
        public ProductsIngredientsRepository(TechContext context) :base(context)
        {
                
        }

        public IEnumerable<ProductsIngredients> GetByProductId(Guid productId)
        {
            try
            {
                var dados = _context.ProductsIngredients.Where(w => w.ProductId == productId);

                if (dados == null) throw new Exception();

                return dados;
            }
            catch (Exception)
            {
                return Enumerable.Empty<ProductsIngredients>();
            }
        }
    }
}
