using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Shop { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
    }
}
