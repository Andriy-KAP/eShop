using eShop.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.Domain.Models
{
    public class ShopingDetails: IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int ShopingCartId { get; set; }
        public ShopingCart ShopingCart { get; set; }
    }
}
