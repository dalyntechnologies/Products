using System.ComponentModel.DataAnnotations;

namespace Products.Api.ViewModels
{
    public class CommentsViewModel
    {

        [Required(ErrorMessage ="Comment is required")]
        public string Comment { get; set; }//
        public int ProductId { get; set; }
    }
}
