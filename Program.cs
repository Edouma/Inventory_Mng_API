using Inventory_Mngt_API.Data;
using Inventory_Mngt_API.Mappings;
using Inventory_Mngt_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryConnectionString")));

builder.Services.AddScoped<IProductRepository, SQLProductRepository>();
builder.Services.AddScoped<IMakeSaleRepository, SQLMakeSaleRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
