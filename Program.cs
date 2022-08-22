using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShoppingList.Context;
using ShoppingList.Dtos;
using ShoppingList.Entities;
using ShoppingList.Repositories;
using ShoppingList.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAppDbContextConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextShop>(op => op.UseSqlServer(MyAppDbContextConnection),ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<IBrandRepository,BrandRepository>();

builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();

builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddScoped<ISupermarketService,SupermarketService>();
builder.Services.AddScoped<ISupermarketRepository,SupermarketRepository>();

builder.Services.AddScoped<IListShopService,ListShopService>();
builder.Services.AddScoped<IListRepository,ListShopRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
