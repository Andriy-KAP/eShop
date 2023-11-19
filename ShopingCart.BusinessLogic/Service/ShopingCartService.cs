using AutoMapper;
using eShop.Common.Contract;
using Microsoft.EntityFrameworkCore;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.DataAccess.Extension;
using ShopingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;

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

        public IEnumerable<ShopingCartDTO> GetShopingCarts(int userId, int page, int count, string filter, string orderBy)
        {
            var result =  _repository.GetAll().Where(_=>_.UserId == userId).Search(filter).Paginate(_ => _.Date, page, count);

            return _mapper.Map<IEnumerable<ShopingCartDTO>>(result);
        }
    }
}
