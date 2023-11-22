using Microsoft.EntityFrameworkCore;
using Nancy;
using Nancy.Owin;
using ProductCatalog;
using ProductCatalog.BusinessLogic;
using ProductCatalog.DataAccess.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductCatalogContext>(_ => _.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));
builder.Services.AddAutoMapper(_=>_.AddProfile(new MapperProfile()));
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
