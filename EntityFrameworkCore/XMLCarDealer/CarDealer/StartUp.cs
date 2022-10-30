using CarDealer.Data;
using CarDealer.DTOOS;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            System.Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult);
            return isValid;
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SupplierDTO[]), new XmlRootAttribute("Suppliers"));
            var objects = (SupplierDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                Supplier prod = new Supplier()
                {
                    Name = item.Name,
                    IsImporter = item.IsImporter,
                };
                if (!IsValid(prod)) continue;
                context.Suppliers.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(PartDTO[]), new XmlRootAttribute("Parts"));
            var objects = (PartDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                if (!context.Suppliers.Any(x => x.Id == item.SupplierId)) continue;
                Part prod = new Part()
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    SupplierId = item.SupplierId
                };
                if (!IsValid(prod)) continue;
                context.Parts.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CarDTO[]), new XmlRootAttribute("Cars"));
            var objects = (CarDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects.Distinct().ToArray())
            {
                if (!IsValid(item)) continue;
                Car prod = new Car()
                {
                    Make = item.Make,
                    Model = item.Model,
                    TravelledDistance = item.TraveledDistance,
                };
                context.Cars.Add(prod);
                context.SaveChanges();
                foreach (var part in item.PartsIds.Select(x => x.Id).Distinct().ToArray())
                {
                    if (!context.Parts.Any(x => x.Id == part)) continue;
                    PartCar p = new PartCar
                    {
                        PartId = part,
                        Car = prod
                    };
                    context.PartCars.Add(p);
                    context.SaveChanges();
                }
                count++;
            }
            return $"Successfully imported {count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CustomerDTO[]), new XmlRootAttribute("Customers"));
            var objects = (CustomerDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                Customer prod = new Customer()
                {
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    IsYoungDriver = item.IsYoungDriver,
                };
                if (!IsValid(prod)) continue;
                context.Customers.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SalesDTO[]), new XmlRootAttribute("Sales"));
            var objects = (SalesDTO[])ser.Deserialize(new StringReader(inputXml));
            int count = 0;
            foreach (var item in objects)
            {
                if (!context.Cars.Select(x => x.Id).Any(x => x == item.CarId)) continue;
                Sale prod = new Sale()
                {
                    CarId = item.CarId,
                    CustomerId = item.CustomerId,
                    Discount = item.Discount
                };
                if (!IsValid(prod)) continue;
                context.Sales.Add(prod);
                count++;
            }
            context.SaveChanges();
            return $"Successfully imported {count}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new CarDTOQ14
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .Take(10)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CarDTOQ14>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, cars, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new CarDTOQ15
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CarDTOQ15>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, cars, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new SupplierDTOQ16 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                }).ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("suppliers");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<SupplierDTOQ16>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, suppliers, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new CarDTOQ17
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new PartsDTOQ17
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    }).OrderByDescending(y => y.Price).ToList()
                }).OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("cars");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CarDTOQ17>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, cars, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new CustomerDTOQ18
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.SelectMany(y => y.Car.PartCars).Sum(e => e.Part.Price)
                }).OrderByDescending(x => x.SpentMoney)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("customers");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CustomerDTOQ18>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, customers, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SaleDTOQ19
                {
                    Car = new CarDTOQ14
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    CustomerName = x.Customer.Name,
                    Discount = Math.Round(x.Discount, 2),
                    Price = x.Car.PartCars.Sum(e => e.Part.Price),
                    PriceWithDiscount = Math.Round(x.Car.PartCars.Sum(e => e.Part.Price) - x.Discount/100 * x.Car.PartCars.Sum(e => e.Part.Price),4)
                }).ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("sales");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<SaleDTOQ19>), root);
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, sales, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
    }
}