using Microsoft.AspNetCore.Mvc;
using Products.Web.Models;
using Products.Web.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Products.Web.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        public IActionResult ProductsPage()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.ProductViewModel product)
        {
            var result = await _productService.AddProductAsync(product);

            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]       
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result=await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> EditProductAsync(int id)
        {
            var response=await _productService.GetProductAsync(id);
            var product = new ProductViewModel();
            product.Id = id;
            product.Name = response.Name;
            product.Price=response.Price;
            product.ReleaseDate = response.ReleaseDate; 
            return View(product);
        }
       
        public async Task<ActionResult> UpdateAsync(Models.ProductViewModel product)
        {
            var result=await _productService.UpdateProductAsync(product);
            return RedirectToAction("Index", "Product");
           
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            var response = await _productService.GetProductAsync(id);
            return View(response);
        }
    }
}
