using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
        public interface IProductRepository
        {
            IEnumerable<Product> Products { get; }
        }
}
