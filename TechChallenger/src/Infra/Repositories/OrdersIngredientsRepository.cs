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
    public class OrdersIngredientsRepository : EfRepository<OrdersIngredients>, IOrdersIngredientsRepository
    {
        public OrdersIngredientsRepository(TechContext context): base(context) { }
    }
}
