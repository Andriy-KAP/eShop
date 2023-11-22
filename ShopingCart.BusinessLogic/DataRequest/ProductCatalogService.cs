using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.BusinessLogic.DataRequest
{
    public static class ProductCatalogService
    {
        private static readonly string apiUrl = "https://localhost:44356/";
        private const string getProductsByIdsTemplate = "/product/getProductsByIds?productIds=[{0}]";

        public static async Task<HttpResponseMessage> RequestProductsByIds(int[] productCatalogIds)
        {
            var productsResource = string.Format(
                    getProductsByIdsTemplate, string.Join(",", productCatalogIds)
                );
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await httpClient.GetAsync(productsResource).ConfigureAwait(false);
            }
        }

    }
}
