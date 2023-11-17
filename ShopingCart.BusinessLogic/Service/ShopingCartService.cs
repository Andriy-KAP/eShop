using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.DataAccess.Bahaviour;
using ShopingCart.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShopingCart.BusinessLogic.Service
{
    public class ShopingCartService : IShopingCartService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ShopingCart.Domain.Models.ShopingCart> _repository;
        public ShopingCartService(IMapper mapper, IRepository<ShopingCart.Domain.Models.ShopingCart> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task AddShopingCart(ShopingCartDTO shopingCart)
        {
            ShopingCart.Domain.Models.ShopingCart cart = _mapper.Map<ShopingCart.Domain.Models.ShopingCart>(shopingCart);
            await _repository.Add(cart);
        }

        public async Task EditShopingCart(ShopingCartDTO shopingCart)
        {
            ShopingCart.Domain.Models.ShopingCart cart = _mapper.Map<ShopingCart.Domain.Models.ShopingCart>(shopingCart);
            await _repository.Update(cart);
        }

        public async Task<IEnumerable<ShopingCartDTO>> GetShopingCart(int userId)
        {
            IEnumerable<ShopingCart.Domain.Models.ShopingCart> result = await _repository.GetAll()
                .Where(_ => _.UserId == userId).Include(_=>_.ShopingDetails).ToListAsync();

            return _mapper.Map<IEnumerable<ShopingCartDTO>>(result);
        }

        public async Task RemoveShopingCart(int id)
        {
            ShopingCart.Domain.Models.ShopingCart targetCart = await _repository.Find(id);
            await _repository.Delete(targetCart);
        }
    }
}
