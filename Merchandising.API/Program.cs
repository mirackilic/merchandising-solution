using System.Text.Json.Serialization;
using Merchandising.Application.IRepositories;
using Merchandising.Application.Services;
using Merchandising.Domain.Context;
using Merchandising.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IMerchandisingDbContext, MerchandisingDbContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
// builder.Services.AddScoped<IMerchandisingDbContext, MerchandisingDbContext>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MerchandisingDbContext>((optionBuilder) =>
optionBuilder.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MerchandisingDbContext))));

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
                
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
