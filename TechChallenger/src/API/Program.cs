using System.Reflection;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers();

// var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
// var dbName = Environment.GetEnvironmentVariable("DB_NAME");
// var dbUser = Environment.GetEnvironmentVariable("DB_USER");
// var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
// var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
//
// builder.Services.AddDbContext<TechContext>(options => options
//     .UseNpgsql($"host={dbHost};database={dbName};username={dbUser};password={dbPass};port={dbPort}"));

builder.Services.AddDbContext<TechContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserUseCase, UserUseCase>();

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientUseCase, IngredientUseCase>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagUseCase, TagUseCase>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderUseCase, OrderUseCase>();

builder.Services.AddScoped<IOrdersProductsRepository, OrdersProductsRepository>();

builder.Services.AddScoped<IOrdersIngredientsRepository, OrdersIngredientsRepository>();

builder.Services.AddScoped<IProductsIngredientsRepository, ProductsIngredientsRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductUseCase, ProductUseCase>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryUseCase, CategoryUseCase>();

builder.Services.AddScoped<IPaymentUseCase, PaymentUseCase>();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tech Challenge v1"); });

app.UseHttpsRedirection();

app.MapControllers();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<TechContext>();
await context.Database.MigrateAsync();

await app.RunAsync();