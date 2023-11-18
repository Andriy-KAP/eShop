using Nancy;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.DTO;

namespace ShopingCart.Modules
{
    public class ShopingCartModule : NancyModule
    {
        private readonly IShopingCartService shopingCartService;
        public ShopingCartModule(IShopingCartService _shopingCartService) : base("/shopingcart")
        {
            shopingCartService = _shopingCartService;
            Get("/{userId:int}", async (parameters) => { return await GetUserShopingCart(parameters.userId); });
            Get("/{page:int}/{count:int}/{filter}/{sortBy}", async (parameters) =>
            {
                return GetPaginatedCollection(parameters.page, parameters.count, parameters.filter, parameters.sortBy);
            });
        }

        private async Task<IEnumerable<ShopingCartDTO>> GetUserShopingCart(int userId)
        {
            return await shopingCartService.GetShopingCart(userId);
        }

        private async Task AddShopingCart(ShopingCartDTO shopingCart)
        {
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

        private IEnumerable<ShopingCartDTO> GetPaginatedCollection(int page, int count, string filter, string orderBy)
        {
            return  shopingCartService.GetShopingCarts(page, count, filter, orderBy);
        }
    }
}
