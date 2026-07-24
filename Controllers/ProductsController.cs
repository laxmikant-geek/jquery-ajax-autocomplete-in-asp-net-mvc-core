using GeekStore.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.Mvc.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        List<Product> products =
        [
            new() { Id = 1, Name = "Galaxy A15 Mobile", Price = 390 },
            new() { Id = 2, Name = "Air Pods", Price = 200 },
        ];
        return View(products);
    }
}
