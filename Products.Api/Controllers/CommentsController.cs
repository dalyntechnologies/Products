using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Api.ViewModels;
using Products.Data;
using Products.Entities;
using System;
using System.Threading.Tasks;

namespace Products.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("comment/{id:int}")]
        public async Task<IActionResult> GetCommentsByProductAsync(int id)
        {
            var comments= await _unitOfWork.Comments.GetCommentsByProduct(id);
            return Ok(comments);
        }
        [HttpPost("comment")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentsViewModel model) 
        { 
            if(ModelState.IsValid)
            {
                if (model == null)
                    return BadRequest($"{nameof(model)} cannot be null");

                var product = await _unitOfWork.Product.GetEntities(model.ProductId);
                if (product==null)
                    return BadRequest("Product not found for comment");
                var newComment= new Comments
                {
                    DateOfComment = DateTime.UtcNow,
                    CommentDescription=model.Comment,
                    ProductId=model.ProductId  

                };
                _unitOfWork.Comments.AddComment(newComment);
                _unitOfWork.SaveChanges();
                return Ok(newComment);
            }
            return BadRequest();
        }
    }
}
