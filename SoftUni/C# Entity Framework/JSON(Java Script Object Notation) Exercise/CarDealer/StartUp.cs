using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");

            string result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        //IMPORT
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSupplierDto[] suppliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var sDto in suppliersDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(sDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportPartDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();

            int[] suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

            foreach (var pDto in partsDtos)
            {
                if (!suppliersIds.Any(sI => sI == pDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(pDto);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();
            return $"Successfully imported {validParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            //ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            //ICollection<Car> cars = new HashSet<Car>();

            ImportCarDto[] carsDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> cars = new HashSet<Car>();
            foreach (var cDto in carsDtos)
            {
                Car car = mapper.Map<Car>(cDto);
                foreach (var p in cDto.PartsId.Distinct())
                {

                    PartCar carPart = new PartCar()
                    {
                        Car = car,
                        PartId = p
                    };

                    car.PartsCars.Add(carPart);
                }

              
                cars.Add(car);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCustomerDto[] customersDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> customers = new HashSet<Customer>();
            foreach (var cDto in customersDtos)
            {
                Customer customer = mapper.Map<Customer>(cDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSalesDto[] salesDtos = JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson);

            ICollection<Sale> validSales = new HashSet<Sale>();

            int[] customerIds = context.Customers.Select(c => c.Id).ToArray();
            int[] carIds = context.Cars.Select(c => c.Id).ToArray();

            foreach (var sDto in salesDtos)
            {               
                Sale sale = mapper.Map<Sale>(sDto);
                validSales.Add(sale);
            }

            context.AddRange(validSales);
            context.SaveChanges();
            return $"Successfully imported {validSales.Count}.";
        }

        //EXPORT

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            ExportCustomerDto[] exportedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .AsNoTracking()
                .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(exportedCustomers, Formatting.Indented);
        }

        //public static string GetCarsFromMakeToyota(CarDealerContext context)
        //{
        //    IMapper mapper = CreateMapper();

        //    ExportCarDto[] exportCars = context.Cars
        //        .Where(c => c.Make == "Toyota")
        //        .OrderBy(c => c.Model)
        //        .ThenByDescending(c => c.TravelledDistance)
        //        .AsNoTracking()
        //        .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
        //        .ToArray();

        //    return JsonConvert.SerializeObject(exportCars, Formatting.Indented);
        //}

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            ExportSupplierDto[] suppliersExport = context.Suppliers
                .Where(ex => ex.IsImporter == false)
                .AsNoTracking()
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(suppliersExport, Formatting.Indented);  
        }

        //public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //{
        //    var carsAndParts = context.Cars
        //        .Select(c => new
        //        {
        //            car = new
        //            {
        //                c.Make,
        //                c.Model,
        //                c.TravelledDistance
        //            },
        //            parts = c.PartsCars
        //                .Select(p => new
        //                {
        //                    p.Part.Name,
        //                    Price = $"{p.Part.Price:f2}"
        //                })
        //        })
        //        .ToArray();

        //    return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
        //}

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(c => c.Part.Price))
                })
                .AsNoTracking()
                .ToArray();

            var totalSalesByCustomer = customers.Select(t => new
            {
                t.fullName,
                t.boughtCars,
                spentMoney = t.spentMoney.Sum()
            })
           .OrderByDescending(t => t.spentMoney)
           .ThenByDescending(t => t.boughtCars)
           .ToArray();

            return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
               .Take(10)
               .Select(s => new
               {
                   car = new
                   {
                       s.Car.Make,
                       s.Car.Model,
                       s.Car.TraveledDistance
                   },
                   customerName = s.Customer.Name,
                   discount = $"{s.Discount:f2}",
                   price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                   priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
               })
               .ToArray();

            return JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            return mapper;
        }
    }
}