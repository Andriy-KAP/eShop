using ProductCatalog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Model
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
