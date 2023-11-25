using Nancy;
using Nancy.ModelBinding;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.Converters;
using ShopingCart.BusinessLogic.DataRequest;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.BusinessLogic.Model;
using ShopingCart.Models;

namespace ShopingCart.Modules
{
    public class ShopingCartModule : NancyModule
    {
        private readonly IShopingCartService shopingCartService;
        public ShopingCartModule(IShopingCartService _shopingCartService) : base("/shopingcart")
        {
            shopingCartService = _shopingCartService;
            Get("/{userId:int}", async (parameters) => {
                try
                {

                    int.TryParse(Request.Query.page.Value, out int page);
                    int.TryParse(Request.Query.count.Value, out int count);
                    return GetPaginatedCollection(parameters.userId,
                        page, count, Request.Query.filter.Value, Request.Query.orderBy.Value);
                }
                catch(Exception ex)
                {
                    return StatusCodes.Status500InternalServerError;
                }
            });
            Post("/{userId:int}", async (parameters, _) =>
            {
                try
                {
                    var newShopingCart = this.Bind<NewShopingCartModel[]>();
                    int.TryParse(parameters.userId, out int userId);
                    var products = await GetProductsByIds(newShopingCart.Select(_ => _.ProductId).ToArray<int>());
                    await AddShopingCart(products.ToList(), newShopingCart.Select(_ => _.Count).ToArray<int>(), userId);
                    return StatusCodes.Status200OK;
                }
                catch(Exception ex)
                {
                    return StatusCodes.Status500InternalServerError;
                }
            });
            Post("/update", async (parameters, _) =>
            {
                try
                {
                    var newShopingCart = this.Bind<ShopingCartDTO>();
                    if(newShopingCart != null)
                    {
                        await UpdateShopingCart(newShopingCart);
                    }
                    return StatusCodes.Status400BadRequest;
                }
                catch (Exception ex)
                {
                    return StatusCodes.Status500InternalServerError;
                }
            });
            Delete("/remove/{cartId:int}", (parameters) =>
            {
                try
                {
                    RemoveShopingCart(parameters.cartId);
                    return StatusCodes.Status200OK;
                }
                catch(Exception ex)
                {
                    return StatusCodes.Status500InternalServerError;
                }
            });
        }

        private async Task<IEnumerable<ShopingCartDTO>> GetUserShopingCart(int userId)
        {
            return await shopingCartService.GetShopingCart(userId);
        }

        private async Task AddShopingCart(List<ProductCatalogProduct> products, int[] countArray ,int userId)
        {
            var shopingDetails = new List<ShopingDetailsDTO>();
            for (int i=0; i <= products.Count() -1; i++)
            {
                shopingDetails.Add(new ShopingDetailsDTO
                {
                    Count = countArray[i],
                    ProductId = products[i].Id,
                });
            }

            var shopingCart = new ShopingCartDTO
            {
                Date = DateTime.UtcNow,
                UserId = userId,
                ShopingDetails= shopingDetails
            };
            await shopingCartService.AddShopingCart(shopingCart);
        }

        private async Task UpdateShopingCart(ShopingCartDTO shopingCart)
        {
            await shopingCartService.EditShopingCart(shopingCart);
        }

        private async Task RemoveShopingCart(int id)
        {
            await shopingCartService.RemoveShopingCart(id);
        }

        private IEnumerable<ShopingCartDTO> GetPaginatedCollection(int userId, int page, int count, string filter, string orderBy)
        {
            return  shopingCartService.GetShopingCarts(userId, page, count, filter, orderBy);
        }

        private async Task<IEnumerable<ProductCatalogProduct>> GetProductsByIds(int[] ids)
        {
            HttpResponseMessage response = await ProductCatalogService.RequestProductsByIds(ids);
            return await response.ConvertToShopingCartItems();
        }
    }
}
