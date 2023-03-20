using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //string jsonInput = File.ReadAllText(@"../../../Datasets/categories-products.json");

            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }
        //                           !!!IMPORTING DTOs From JSON file!!!
        // 1) We have the Json file!
        // 2) We create the DTO class with the values that the JSON file is providing us!
        // 3) We add an Mapping configuarion in the mapper profile, from DTO => Model (Can have additional settings)!
        // 4) We are Deserializing the JSON file into our DTOs!
        // 5) We create an instance of the mapper and we do additional validations on the DTO before mapping it to the model!
        // 6) We mapp it to the model, and then we add it to the Database!
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var u in userDtos)
            {
                User user = mapper.Map<User>(u);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productsDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> products = new HashSet<Product>();
            foreach (var pDto in productsDtos)
            {
                Product product = mapper.Map<Product>(pDto);

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var cDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(cDto.Name))
                {
                    continue;
                }

                Category currCategory = mapper.Map<Category>(cDto);
                validCategories.Add(currCategory);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoriesProductsDto[] categoriesAndProductsDtos =
                JsonConvert.DeserializeObject<ImportCategoriesProductsDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            //int[] productsIds = context.Products.Select(p => p.Id).ToArray();
            //int[] categoryIds = context.Categories.Select(c => c.Id).ToArray();

            foreach (var cpDto in categoriesAndProductsDtos)
            {
                if (!context.Products.Any(pId => pId.Id == cpDto.ProductId) ||
                    !context.Categories.Any(cId => cId.Id == cpDto.CategoryId))
                {
                    continue;
                }

                CategoryProduct categotyProduct = mapper.Map<CategoryProduct>(cpDto);

                validCategoryProducts.Add(categotyProduct);
            }
            
            context.CategoriesProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //Exporting DTOs
        //We make the DTO
        //We Serialize the Model to the DT0
        //Then we Convert the DTO into JSon

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            //var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000).OrderBy(p => p.Price)
            //    .Select(p => new
            //    {
            //        name = p.Name,
            //        price = p.Price.ToString("f2"),
            //        seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            //    }).AsNoTracking().ToArray();

            ExportProductDto[] productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            ExportUsersDto[] exportUsedDtos = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .AsNoTracking()
                .ProjectTo<ExportUsersDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(exportUsedDtos, Formatting.Indented);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            ExportCategotyDto[] exportedCategoryDto = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count())
                .AsNoTracking()
                .ProjectTo<ExportCategotyDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(exportedCategoryDto, Formatting.Indented);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    // UserDTO
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        // ProductWrapperDTO
                        Count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                // ProductDTO
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            return mapper;
        }

    }



}