namespace Simple_Pages.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json;
    using Simple_Pages.Models.Products;
    using System.Text;
    using System.Text.Json;

    public class ProductController : Controller
    {
        private readonly ICollection<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00m
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50m
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50m
            }
        };

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var filteredProducts = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();

                return View(filteredProducts);
            }
            return View(products);
        }


        public IActionResult ById(int id)
        {
            ProductViewModel product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return View("Error");
            }
             
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            return Json(products, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new();

            foreach (var item in products)
            {
                sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price:f2} $.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition,
                @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
