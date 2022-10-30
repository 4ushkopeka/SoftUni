using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static DefaultContractResolver cont = new DefaultContractResolver()
        {
            NamingStrategy = new DefaultNamingStrategy()
        };
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ContractResolver = cont,
            Formatting = Formatting.Indented
        };
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var peeps = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            foreach (var item in peeps)
            {
                if (!IsValid(item)) continue;
                context.Suppliers.Add(item);
            }
            context.SaveChanges();
            return $"Successfully imported {peeps.Length}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var peeps = JsonConvert.DeserializeObject<Part[]>(inputJson);
            int count = 0;
            foreach (var item in peeps)
            {
                if (!IsValid(item) || !context.Suppliers.Select(x => x.Id).Any(x => x == item.SupplierId)) continue;
                context.Parts.Add(item);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var peeps = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);
            int count = 0;
            foreach (var item in peeps.Distinct().ToArray())
            {
                if (!IsValid(item)) continue;
                Car cr = new Car
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TravelledDistance
                };
                context.Cars.Add(cr);
                context.SaveChanges();
                foreach (var part in item.PartsId.Distinct().ToArray())
                {
                    if (!context.Parts.Any(x => x.Id == part)) continue;
                    PartCar p = new PartCar 
                    { 
                        PartId = part,
                        Car = cr
                    };
                    context.PartCars.Add(p);
                    context.SaveChanges();
                }
                count++;
            }
                return $"Successfully imported {count}.";
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var peeps = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            int count = 0;
            foreach (var item in peeps)
            {
                if (!IsValid(item)) continue;
                context.Customers.Add(item);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var peeps = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            int count = 0;
            foreach (var item in peeps)
            {
                if (!IsValid(item)) continue;
                context.Sales.Add(item);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var peeps = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    x.IsYoungDriver
                })
                .ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var peeps = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var peeps = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var peeps = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(t => new
                    {
                        t.Part.Name,
                        Price = $"{t.Part.Price:f2}"
                    }).ToList()
                })
                .ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var peeps = context.Customers
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = Math.Round(x.Sales.SelectMany(e => e.Car.PartCars).Sum(e => e.Part.Price),2)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenBy(x => x.BoughtCars)
                .ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var peeps = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("f2"),
                    price = x.Car.PartCars.Sum(e => e.Part.Price),
                    priceWithDiscount = x.Car.PartCars.Sum(e => e.Part.Price) - x.Discount/100*x.Car.PartCars.Sum(e => e.Part.Price)
                }).Take(10).ToList();
            return JsonConvert.SerializeObject(peeps, settings);
        }
    }
}