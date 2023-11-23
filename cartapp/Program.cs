using cartApp.Repository;
using cartApp.Repository.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using cartApp.Repository.Repository.Common;
using cartApp.Repository.Repository;
using cartApp.Services.Infrastructure;
using cartApp.Services.Implementation;
using cartApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CartAppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(CartAppDbContext).Assembly.FullName))
    );


builder.Services.AddControllers();
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile)); 
// MappingProfile.cs should be in cartApp.Services
// because that's where all business logic goes
// and that's where we need to do all the mapping.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CartAppDbContext>(options =>
{
    // your options configuration
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IDbFactory, DbFactory>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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
