using ProductCatalog.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessLogic.Behaviour
{
    public interface IProductService
    {
        Task AddProduct(ProductDTO product);
        Task UpdateProduct(ProductDTO product);
        Task RemoveProduct(int id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId, int page, int count, string filter, string orderBy);
        Task<ProductDTO> GetProduct(int id);
        Task<IEnumerable<ProductDTO>> GetProducts(int page, int count, string filter, string orderBy);
        Task<IEnumerable<ProductDTO>> GetProductsByIds(IEnumerable<int> ids);
    }
}
