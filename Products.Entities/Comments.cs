using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string CommentDescription { get; set; }
        public DateTime DateOfComment { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
