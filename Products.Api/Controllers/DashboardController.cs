using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("totalproducts")]
        public async Task<IActionResult> GetTotalProductsAsync()
        {
            var results = await _unitOfWork.Product.GetTotalProducts();
            var response = new
            {
                TotalProducts = results,
            };
            return Ok(response);
        }
        [HttpGet("commentsperproduct")]
        public async Task<IActionResult> GetCommentsPerProductAsync()
        {
            var results = await _unitOfWork.Product.GetEntities();
            var response = results.Select(a => new
            {
                Name=a.Name,
                Total=a.Comments.Count(),
            });
            return Ok(response);
        }
    }
}
