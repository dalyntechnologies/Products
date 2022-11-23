using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Api.ViewModels;
using Products.Data;
using Products.Entities;
using System.Threading.Tasks;

namespace Products.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        [HttpGet("product")]
        public async Task<IActionResult> GetProductAsync()
        {
            if (ModelState.IsValid)
            {
                var data=await _unitOfWork.Product.GetEntities();
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpGet("product/{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.Product.GetEntities(id);      
            return Ok(product);
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreatetProductAsync([FromBody] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                    return BadRequest($"{nameof(model)} cannot be null");

                var hasProduct = await _unitOfWork.Product.HasProductByName(model.Name);
                if (hasProduct)
                    return BadRequest("Product already exist");
                var newProduct = new Product
                {
                    Price = model.Price,
                    Name = model.Name,
                    ReleaseDate = model.ReleaseDate
                };
                _unitOfWork.Product.AddEntity(newProduct);
                _unitOfWork.SaveChanges();
                return Ok(newProduct);
            }
            return BadRequest();
        }


        [HttpPut("product/{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                    return BadRequest($"{nameof(model)} cannot be null");

                if (model.Id == 0 && id != model.Id)
                    return BadRequest("Conflicting product id in parameter and model data");
                var product = await _unitOfWork.Product.GetEntities(model.Id);
                if (product == null)
                    return NotFound(id);
                product.Price = model.Price;
                product.Name = model.Name;
                product.ReleaseDate = model.ReleaseDate;

                _unitOfWork.Product.UpdateEntity(product);
                _unitOfWork.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }


        [HttpDelete("product/{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await _unitOfWork.Product.GetEntities(id);
            if (product == null)
                return NotFound(id);
            _unitOfWork.Product.DeleteEntity(product);
            _unitOfWork.SaveChanges();
            return Ok(product);
        }
    }
}
