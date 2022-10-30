using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            Console.WriteLine(GetUsersWithProducts(context));
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XDocument doc = XDocument.Parse(inputXml);
            var users = doc.Root.Elements();
            int count = 0;
            foreach (var item in users)
            {
                User user = new User() 
                { 
                    FirstName = item.Element("firstName").Value,
                    LastName = item.Element("lastName").Value,
                    Age = int.Parse(item.Element("age").Value)
                };
                if (!IsValid(user)) continue;
                context.Users.Add(user);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProductDTO[]), new XmlRootAttribute("Products"));
            var objects = (ProductDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                Product prod = new Product() 
                { 
                    Name = item.Name,
                    Price = item.Price,
                   //SellerId = item.SellerId,
                   //BuyerId = item.BuyerId,
                };
                if (!IsValid(prod)) continue;
                context.Products.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CategoryDTO[]), new XmlRootAttribute("Categories"));
            var objects = (CategoryDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                Category prod = new Category()
                {
                    Name = item.Name,
                };
                if (!IsValid(prod)) continue;
                context.Categories.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProdCatDTO[]), new XmlRootAttribute("CategoryProducts"));
            var objects = (ProdCatDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            var prods = context.Products.ToList();
            var cats = context.Categories.ToList();
            foreach (var item in objects)
            {
                if (!prods.Any(x => x.Id == item.ProductId) || !cats.Any(x => x.Id == item.CategoryId)) continue;
                CategoryProduct prod = new CategoryProduct()
                {
                    CategoryId = item.CategoryId,
                    ProductId = item.ProductId
                };
                if (!IsValid(prod)) continue;
                context.CategoryProducts.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price>499 && x.Price<1001)
                .OrderBy(x => x.Price)
                .Select(x => new ProductDTO()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Take(10)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Products");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<ProductDTO>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, products, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count>0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UserDTOQ6()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(e => new ProductDTOQ6() 
                    { 
                        Name = e.Name,
                        Price = e.Price,
                    }).ToList()
                })
                .Take(5)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<UserDTOQ6>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, users, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var cats = context.Categories
                .Select(x => new CategoryDTOQ7()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(e => e.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(e => e.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CategoryDTOQ7>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, cats, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var cats = new MasterDTOQ8() 
            { 
                Users = context.Users
                .Where(x => x.ProductsSold.Any(r => r.BuyerId.HasValue))
                .OrderByDescending(x => x.ProductsSold.Count(r => r.BuyerId.HasValue))
                .Select(x => new UserDTOQ8
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProdsDTOQ8
                    {
                        Products = x.ProductsSold.Where(e => e.BuyerId.HasValue).Select(e => new ProductDTOQ6()
                        {
                            Name = e.Name,
                            Price = e.Price
                        }).OrderByDescending(e => e.Price).ToList(),
                    }
                }).Take(10).ToList(),
            };
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(MasterDTOQ8), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, cats, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
    }
}