using System;
using System.ComponentModel.DataAnnotations;

namespace Products.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name is Required")]
        public string Name { get; set; }


        public decimal Price { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public DateTime ReleaseDate { get; set; }
    }
}
