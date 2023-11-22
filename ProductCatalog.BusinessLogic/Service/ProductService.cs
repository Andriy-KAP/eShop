using AutoMapper;
using eShop.Common.Contract;
using eShop.Common.Extension;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessLogic.Behaviour;
using ProductCatalog.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessLogic.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCatalog.Domain.Model.Product> _repository;
        public ProductService(IMapper mapper, IRepository<ProductCatalog.Domain.Model.Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task AddProduct(ProductDTO productDto)
        {
            ProductCatalog.Domain.Model.Product product = _mapper.Map<ProductCatalog.Domain.Model.Product>(productDto);
            await _repository.Add(product);
        }
        public async Task<ProductDTO> GetProduct(int id)
        {
            var result = await _repository.Find(id);
            return _mapper.Map<ProductDTO>(result);
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts(int page, int count, string filter, string orderBy)
        {
            var result = await _repository.GetAll().Search(filter).Paginate(_ => _.Id, page, count).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var result = await _repository.GetAll().ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId, int page, int count, string filter, string orderBy)
        {
            var result = await _repository.GetAll()
                .Where(_=>_.CategoryId== categoryId)
                .Search(filter).Paginate(_ => _.Id, page, count).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task RemoveProduct(int id)
        {
            ProductCatalog.Domain.Model.Product product = await _repository.Find(id);
            await _repository.Delete(product);
        }
        public async Task UpdateProduct(ProductDTO productDto)
        {
            ProductCatalog.Domain.Model.Product product = _mapper.Map<ProductCatalog.Domain.Model.Product>(productDto);
            await _repository.Update(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByIds(IEnumerable<int> ids)
        {
            IEnumerable<ProductCatalog.Domain.Model.Product> products = await _repository.GetAll().Where(_ => ids.Contains(_.Id))
                .ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
