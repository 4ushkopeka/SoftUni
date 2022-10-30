using ASPEx.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ASPEx.Controllers
{
    public class ProductsController : Controller
    {
        List<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel(){Id = 1, Name = "Cheese", Price = 7 },
            new ProductViewModel(){Id = 2, Name = "Piper", Price = 4 },
            new ProductViewModel(){Id = 3, Name = "Paprika", Price = 6 }
        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
        {
            return View(products);
        }
        public IActionResult AllAsJson()
        {
            ViewBag.Message = JsonConvert.SerializeObject(products, Formatting.Indented);
            return View();
        }
        public IActionResult ById(int id)
        {
            ProductViewModel model = products.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
