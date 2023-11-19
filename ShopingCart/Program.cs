using AutoMapper;
using eShop.Common.Contract;
using eShop.Common.Repository_;
using Microsoft.EntityFrameworkCore;
using Nancy;
using Nancy.Owin;
using ShopingCart;
using ShopingCart.BusinessLogic.Behaviour;
using ShopingCart.BusinessLogic.DTO;
using ShopingCart.BusinessLogic.Service;
using ShopingCart.DataAccess.Core;
using ShopingCart.Domain.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IShopingCartService, ShopingCartService>();
builder.Services.AddTransient<IRepository<ShopingCart.Domain.Models.ShopingCart>, Repository<ShopingCart.Domain.Models.ShopingCart, ShopingCartContext>>();
builder.Services.AddDbContext<ShopingCartContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

app.UseOwin(opt =>
{
    opt.UseNancy(options => {
        options.Bootstrapper = new Bootstrapper(app.Services);
    });
});

app.Run();
