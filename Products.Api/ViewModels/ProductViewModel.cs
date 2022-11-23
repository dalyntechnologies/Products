using System;
using System.ComponentModel.DataAnnotations;

namespace Products.Api.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product Name is required")]
        public string Name { get; set; }      
        public decimal Price { get; set; }    
        public DateTime ReleaseDate { get; set; }
    }
}
