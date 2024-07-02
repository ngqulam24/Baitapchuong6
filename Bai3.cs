using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

public class ProductManager
{
    public static List<Product> ReadProductsFromJson(string filePath)
    {
        var products = new List<Product>();

        using (var stream = File.OpenRead(filePath))
        {
            products = JsonSerializer.Deserialize<List<Product>>(stream);
        }

        return products;
    }

    public static void WriteProductsToJson(string filePath, IEnumerable<Product> products)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(products, options);

        File.WriteAllText(filePath, json);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 9.99, Category = "Category A" },
            new Product { Id = 2, Name = "Product 2", Price = 14.50, Category = "Category B" },
            new Product { Id = 3, Name = "Product 3", Price = 7.25, Category = "Category A" }
        };

        ProductManager.WriteProductsToJson("products.json", products);
        var productsFromFile = ProductManager.ReadProductsFromJson("products.json");

        foreach (var product in productsFromFile)
        {
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}");
        }
    }
}