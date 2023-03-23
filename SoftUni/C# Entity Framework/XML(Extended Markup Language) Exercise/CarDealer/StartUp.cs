using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] supplierDtos = Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var sDto in supplierDtos)
            {
                Supplier currSupplier = mapper.Map<Supplier>(sDto);

                validSuppliers.Add(currSupplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] partDtos = Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();

            int[] existingIds = context.Suppliers.Select(s => s.Id).ToArray();

            foreach (var pDto in partDtos)
            {
                if (!existingIds.Any(i => i == pDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(pDto);

                validParts.Add(part);
            }

            context.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            ImportCarDto[] carDtos = Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();

            foreach (ImportCarDto car in carDtos)
            {
                Car currCar = mapper.Map<Car>(car);

                foreach (var currPartId in car.Parts.DistinctBy(p => p.Id))
                {
                    if (!context.Parts.Any(p => p.Id == currPartId.Id))
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        PartId = currPartId.Id
                    };

                    currCar.PartsCars.Add(partCar);
                }

                validCars.Add(currCar);
            }


            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customersDtos = Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (var cDto in customersDtos)
            {
                Customer customer = mapper.Map<Customer>(cDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            ImportSaleDto[] salesDtos = Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<Sale> sales = new HashSet<Sale>();
            int[] carIds = context.Cars.Select(c => c.Id).ToArray();
            int[] customerIds = context.Customers.Select(c => c.Id).ToArray();


            foreach (var sDto in salesDtos)
            {
                Sale sale = mapper.Map<Sale>(sDto);

                if (!carIds.Any(ci => ci == sale.CarId))
                {
                    continue;
                }

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //public static string GetCarsWithDistance(CarDealerContext context)
        //{
        //    ExportCarDto[] exportCarDtos = context.Cars
        //        .Where(c => c.TraveledDistance > 2_000_000)
        //        .OrderBy(c => c.Make)
        //        .ThenBy(c => c.Model)
        //        .Take(10)
        //        .Select(c => new ExportCarDto
        //        {
        //            Make = c.Make,
        //            Model = c.Model,
        //            TraveledDistance = c.TraveledDistance
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return Serialize(exportCarDtos, "cars");
        //}

        //public static string GetCarsFromMakeBmw(CarDealerContext context)
        //{
        //    ExportCarDto2[] carsDtos = context.Cars
        //        .Where(c => c.Make == "BMW")
        //        .OrderBy(c => c.Model)
        //        .ThenByDescending(c => c.TraveledDistance)
        //        .Select(c => new ExportCarDto2
        //        {
        //            Id = c.Id,
        //            Model = c.Model,
        //            TraveledDistance = c.TraveledDistance
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return Serialize(carsDtos, "cars");
        //}

        //public static string GetLocalSuppliers(CarDealerContext context)
        //{
        //    //Get all suppliers that do not import parts from abroad.Get their id, name and the number of parts they can offer to supply.
        //    ExportSupplierDto[] suppliersDtos = context.Suppliers
        //        .Where(s => s.IsImporter != true)
        //        .Select(s => new ExportSupplierDto()
        //        {
        //            Id = s.Id,
        //            Name = s.Name,
        //            PartsCount = s.Parts.Count
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return Serialize(suppliersDtos, "suppliers");

        //}

        //public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //{
        //    ExportCarDto[] exportedCars = context.Cars
        //        .OrderByDescending(c => c.TraveledDistance)
        //        .ThenBy(c => c.Model)
        //        .Take(5)
        //        .Select(c => new ExportCarDto()
        //        {
        //            Model = c.Model,
        //            Make = c.Make,
        //            TraveledDistance = c.TraveledDistance,
        //            Parts = c.PartsCars.Select(p => new ExportPartDto[]
        //            {
        //                Name = p.Part.Name,
        //                Price = p.Part.Price
        //            }).ToArray(),    
        //            .OrderByDescending(p => p.Price)
        //            .ToArray(),
        //        })
        //        .AsNoTracking()
        //        .ToArray();

        //    return Serialize(exportedCars, "cars");
        //}

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            ExportCustomerDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new ExportCustomerDto()
                {
                    FullName = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return Serialize(totalSalesDtos, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] sales = context.Sales
                .Select(s => new ExportSaleDto()
                {
                    SingleCar = new SingleCar()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .AsNoTracking()
                .ToArray();

            return Serialize(sales, "sales");
        }

        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            return mapper;
        }

        public static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T deserializedDtos =
                (T)xmlSerializer.Deserialize(reader);

            return deserializedDtos;
        }

        public static IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T[] supplierDtos =
                (T[])xmlSerializer.Deserialize(reader);

            return supplierDtos;
        }

        public static string Serialize<T>(T obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot =
                new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }


        public static string Serialize<T>(T[] obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot =
                new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}