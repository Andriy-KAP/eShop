using AutoMapper;
using Nancy;
using Nancy.Configuration;
using Nancy.TinyIoc;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.BusinessLogic.Service;
using ShopingCart.DataAccess.Bahaviour;
using ShopingCart.DataAccess.Core;

namespace ShopingCart
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

            container.Register(_serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ShopingCartContext>());
            container.Register<IShopingCartService, ShopingCartService>().AsMultiInstance();
            container.Register<IRepository<ShopingCart.Domain.Models.ShopingCart>, Repository<ShopingCart.Domain.Models.ShopingCart>>().AsMultiInstance();
            container.Register(_serviceProvider.GetService<IMapper>());
        }
    }
}
