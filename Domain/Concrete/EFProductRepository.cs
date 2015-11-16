using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFProductRepository:Abstract.IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
