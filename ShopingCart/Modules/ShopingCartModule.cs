﻿using Nancy;
using Nancy.ModelBinding;
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
            Get("/{userId:int}", async (parameters) => {
                int.TryParse(Request.Query.page.Value, out int page);
                int.TryParse(Request.Query.count.Value, out int count);
                return GetPaginatedCollection(parameters.userId,
                    page, count, Request.Query.filter.Value, Request.Query.orderBy.Value);
            });
            //Post("/{userId:int}", async (parameters, _) =>
            //{
                //var productIds = this.Bind<int[]>();
                //int.TryParse(parameters.userId, out int userId);

            //});
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

        private IEnumerable<ShopingCartDTO> GetPaginatedCollection(int userId, int page, int count, string filter, string orderBy)
        {
            return  shopingCartService.GetShopingCarts(userId, page, count, filter, orderBy);
        }
    }
}
