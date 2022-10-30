using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static DefaultContractResolver cont = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = cont,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            Console.WriteLine(GetUsersWithProducts(context));
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var additions = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(additions);
            context.SaveChanges();
            return $"Successfully imported {additions.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var additions = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(additions);
            context.SaveChanges();
            return $"Successfully imported {additions.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var additions = JsonConvert.DeserializeObject<Category[]>(inputJson);
            context.Categories.AddRange(additions.Where(x => x.Name != null).ToArray());
            context.SaveChanges();
            return $"Successfully imported {additions.Where(x => x.Name != null).ToArray().Length}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var additions = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(additions);
            context.SaveChanges();
            return $"Successfully imported {additions.Length}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price<=1000 && x.Price>=500)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    x.Name,
                    x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"   
                }).ToList();
            return JsonConvert.SerializeObject(products, settings);
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.BuyerId.HasValue))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold.Where(r => r.BuyerId.HasValue).Select(y => new
                    {
                        y.Name,
                        y.Price,
                        BuyerFirstName = y.Buyer.FirstName,
                        BuyerLastName = y.Buyer.LastName
                    })
                }).ToList();
            return JsonConvert.SerializeObject(users, settings);
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = $"{x.CategoryProducts.Average(y => y.Product.Price):f2}",
                    TotalRevenue = $"{x.CategoryProducts.Sum(y => y.Product.Price):f2}"
                }).ToList();
            return JsonConvert.SerializeObject(categories, settings);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.BuyerId.HasValue))
                .OrderByDescending(x => x.ProductsSold.Count(r => r.BuyerId.HasValue))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Count(d => d.BuyerId.HasValue),
                        Products = x.ProductsSold.Where(e => e.BuyerId.HasValue)
                        .Select(e => new
                        {
                            e.Name,
                            e.Price
                        }).ToList()
                    }
                }).ToList();
            var template = new
            {
                UsersCount = users.Count,
                Users = users
            };
            return JsonConvert.SerializeObject(template, settings);
        }
    }
}