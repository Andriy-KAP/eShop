using AutoMapper;
using eShop.Common.Contract;
using eShop.Common.Repository_;
using Nancy;
using Nancy.Configuration;
using Nancy.TinyIoc;
using ProductCatalog.BusinessLogic.Behaviour;
using ProductCatalog.BusinessLogic.Service;
using ProductCatalog.DataAccess.Core;

namespace ProductCatalog
{
    public class Bootstrapper: DefaultNancyBootstrapper
    {
        private readonly IServiceProvider _serviceProvider;

        public Bootstrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(_serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ProductCatalogContext>());
            container.Register<IProductService, ProductService>().AsMultiInstance();
            container.Register<IRepository<ProductCatalog.Domain.Model.Product>, Repository<ProductCatalog.Domain.Model.Product, ProductCatalogContext>>().AsMultiInstance();
            container.Register(_serviceProvider.GetService<IMapper>());
        }
    }
}
