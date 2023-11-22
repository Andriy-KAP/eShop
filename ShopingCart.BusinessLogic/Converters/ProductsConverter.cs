using Newtonsoft.Json;
using ShopingCart.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.BusinessLogic.Converters
{
    public static class ProductsConverter
    {
        public static async Task<IEnumerable<ProductCatalogProduct>> ConvertToShopingCartItems(this HttpResponseMessage response)
        {
            var test = response.EnsureSuccessStatusCode();
            var products = JsonConvert.DeserializeObject<List<ProductCatalogProduct>>(
                await response.Content.ReadAsStringAsync());

            return products;
        }
    }
}
