using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.Context;

public class TechContext : DbContext
{
    public TechContext(DbContextOptions<TechContext> options): base(options)
    {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrdersIngredients> OrdersIngredients { get; set; }
    public DbSet<OrdersProducts> OrdersProducts { get; set; }
    public DbSet<ProductsIngredients> ProductsIngredients { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProductsTags> ProductsTags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}