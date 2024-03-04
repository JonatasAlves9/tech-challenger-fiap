using System.Reflection;
using Application.UseCases;
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

builder.Services.AddDbContext<TechContext>(options => options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserUseCase, UserUseCase>();

builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();
builder.Services.AddTransient<IIngredientUseCase, IngredientUseCase>();

builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<ITagUseCase, TagUseCase>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderUseCase, OrderUseCase>();

builder.Services.AddTransient<IOrdersProductsRepository, OrdersProductsRepository>();

builder.Services.AddTransient<IOrdersIngredientsRepository, OrdersIngredientsRepository>();

builder.Services.AddTransient<IProductsIngredientsRepository, ProductsIngredientsRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductUseCase, ProductUseCase>();

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryUseCase, CategoryUseCase>();


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
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tech Challenge v1");
});

app.UseHttpsRedirection();


app.MapControllers();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<TechContext>();
await context.Database.MigrateAsync();

await app.RunAsync();
