using Microsoft.EntityFrameworkCore;
using Project.Dal;
using Project.Dto;
using Project.Entity.Concretes;
using Project.Repos.Abstracts;
using Project.Repos.Concretes;
using Project.Uw;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("/*http://127.0.0.1:5500*/", //adresi biz yerleþtirdik.
                          //                    "/*http://www.contoso.com*/");
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
}); //bunu javascript iþlemi esnasýnda CORS policy hatasý nedeniyle https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0 sitesinden alýndý.

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoryRep, CategoryRep<Category>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IProductsRep, ProductsRep<Products>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IUserRep, UserRep<Users>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IColourRep, ColourRep<Colour>>();
builder.Services.AddScoped<IBrandRep, BrandRep<Brand>>();
builder.Services.AddScoped<IModelRep, ModelRep<Model>>();
builder.Services.AddScoped<ProductsCRUDModel>();
builder.Services.AddScoped<BasketDetailCRUDModel>();
builder.Services.AddScoped<Products>();
builder.Services.AddScoped<BasketDetail>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<UserCRUDModel>();
builder.Services.AddScoped<Users>();





var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();
