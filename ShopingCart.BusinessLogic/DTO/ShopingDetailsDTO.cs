using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.BusinessLogic.DTO
{
    public class ShopingDetailsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int ShopingCartId { get; set; }
    }
}
