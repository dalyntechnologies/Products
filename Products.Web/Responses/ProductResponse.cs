using System.ComponentModel.DataAnnotations;
using System;

namespace Products.Web.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
