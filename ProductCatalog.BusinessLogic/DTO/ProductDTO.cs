using ProductCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessLogic.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
