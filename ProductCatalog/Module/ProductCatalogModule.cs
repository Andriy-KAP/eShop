using Nancy;
using ProductCatalog.BusinessLogic.Behaviour;
using ProductCatalog.BusinessLogic.DTO;
using System.Text.Json;

namespace ProductCatalog.Module
{
    public class ProductCatalogModule: NancyModule
    {
        private readonly IProductService _productService;

        public ProductCatalogModule(IProductService productService):base("/product")
        {
            _productService = productService;
            Get("/getProductsByIds", async (parameters) =>
            {
                int[] productIds = JsonSerializer.Deserialize(Request.Query.productIds.Value, typeof(int[]));
                return await GetProductsByIds(productIds);
            });

            Get("/getproducts", async (parameters) =>
            {
                return await GetProducts();
            });
        }

        private async Task<IEnumerable<ProductDTO>> GetProductsByIds(int[] ids)
        {
            return await _productService.GetProductsByIds(ids);
        }

        private async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _productService.GetProducts();
        }
    }
}
