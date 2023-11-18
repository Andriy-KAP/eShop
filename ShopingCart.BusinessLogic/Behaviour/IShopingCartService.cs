using ShopingCart.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.BusinessLogic.Behaviour
{
    public interface IShopingCartService
    {
        Task AddShopingCart(ShopingCartDTO shopingCart);
        Task EditShopingCart(ShopingCartDTO shopingCart);
        Task RemoveShopingCart(int id);
        Task<IEnumerable<ShopingCartDTO>> GetShopingCart(int userId);
        IEnumerable<ShopingCartDTO> GetShopingCarts(int userId, int page, int count, string filter, string orderBy);
    }
}
