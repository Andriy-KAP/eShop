using AutoMapper;

namespace ProductCatalog.BusinessLogic
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductCatalog.Domain.Model.Product, ProductCatalog.BusinessLogic.DTO.ProductDTO>();
            CreateMap<ProductCatalog.Domain.Model.Category, ProductCatalog.BusinessLogic.DTO.CategoryDTO>();
        }
    }
}
