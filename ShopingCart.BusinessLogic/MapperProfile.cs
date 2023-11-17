using AutoMapper;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.BusinessLogic
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ShopingCart.Domain.Models.ShopingCart, ShopingCart.BusinessLogic.DTO.ShopingCartDTO>();
            CreateMap<ShopingDetails, ShopingCart.BusinessLogic.DTO.ShopingDetailsDTO>();
        }
    }
}
