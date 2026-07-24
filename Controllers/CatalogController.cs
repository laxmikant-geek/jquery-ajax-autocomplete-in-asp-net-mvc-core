using Microsoft.AspNetCore.Mvc;

namespace GeekStore.Mvc.Controllers;

public class CatalogController : Controller
{
    private static readonly Dictionary<int, string[]> ProductsByCategory = new()
    {
        [1] = ["Galaxy A15 Mobile", "Pixel 9", "iPhone 16"],
        [2] = ["Air Pods", "Sony WH-1000XM5", "JBL Flip"],
        [3] = ["Pen drive", "SSD 1TB", "MicroSD 256GB"],
    };

    private static readonly string[] AllProducts = ProductsByCategory.Values.SelectMany(x => x).ToArray();

    public IActionResult Index() => View();

    // classic JsonResult endpoint
    public JsonResult Categories() =>
        Json(new[] { new { id = 1, name = "Mobiles" }, new { id = 2, name = "Audio" }, new { id = 3, name = "Storage" } });

    // cascading: products for a category
    public JsonResult Products(int categoryId) =>
        Json(ProductsByCategory.TryGetValue(categoryId, out var p) ? p : []);

    // autocomplete: matching product names
    public JsonResult Suggest(string term) =>
        Json(AllProducts.Where(p => p.Contains(term ?? "", StringComparison.OrdinalIgnoreCase)).Take(8));
}
