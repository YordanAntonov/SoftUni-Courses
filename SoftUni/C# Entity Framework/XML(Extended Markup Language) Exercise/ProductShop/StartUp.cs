using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlHelper helper = new XmlHelper();

            ImportUserDto[] usersDtos = helper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto u in usersDtos)
            {
                User user = mapper.Map<User>(u);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productsDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var pDto in productsDtos)
            {
                Product product = mapper.Map<Product>(pDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var cDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(cDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(cDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            ImportCategoriesProductsDto[] cpDtos = xmlHelper.Deserialize<ImportCategoriesProductsDto[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> categoriesAndProducts = new HashSet<CategoryProduct>();

            //int[] categoryIds = context.Categories.Select(c => c.Id).ToArray();
            //int[] productsIds = context.Products.Select(p => p.Id).ToArray();

            foreach (var cpDto in cpDtos)
            {
                //if (!categoryIds.Any(c => c == cpDto.CategoryId) ||
                //    !productsIds.Any(p => p == cpDto.ProductId))
                //{
                //    continue;
                //}

                CategoryProduct categoryPr = new CategoryProduct()
                {
                    CategoryId = cpDto.CategoryId,
                    ProductId = cpDto.ProductId
                };

                categoriesAndProducts.Add(categoryPr);
            }

            //context.CategoryProducts.AddRange(categoriesAndProducts);
            //context.SaveChanges();
            return $"Successfully imported {categoriesAndProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportProductDto[] exportedProductsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .AsNoTracking()
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(exportedProductsDtos, "Products");

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new XmlHelper();

            ExportUserDto[] usersDtos = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .AsNoTracking()
                .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(usersDtos, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            var categoryDtos = context.Categories
                .Select(c => new
                {
                    name = c.Name,
                    count = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(c => c.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(c => c.Product.Price)
                }).OrderByDescending(p => p.count).ThenBy(p => p.totalRevenue)
                .AsNoTracking()
                .ToArray();

            List<ExportCategoryDto> category = new List<ExportCategoryDto>();
            foreach (var cDto in categoryDtos)
            {
                ExportCategoryDto categoryDto = new ExportCategoryDto()
                {
                    Name = cDto.name,
                    Count = cDto.count,
                    AveragePrice = cDto.averagePrice,
                    TotalRevenue = cDto.totalRevenue
                };

                category.Add(categoryDto);
            }

            return xmlHelper.Serialize(category, "Categories");

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var userDtos = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportCountAndListOfProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductListDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }

                })
                .AsNoTracking()
                .Take(10)
                .ToArray();

            ExportUsersDtos users = new ExportUsersDtos()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = userDtos
            };

            return xmlHelper.Serialize(users, "Users");
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