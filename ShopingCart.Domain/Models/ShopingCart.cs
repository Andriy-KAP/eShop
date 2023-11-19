using eShop.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.Domain.Models
{
    public class ShopingCart: IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ShopingDetails> ShopingDetails { get; set; }
    }
}
