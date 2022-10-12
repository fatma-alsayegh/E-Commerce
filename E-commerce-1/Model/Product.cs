using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_1
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Icon { get; set; }
        public int CategoryId { get; set; }//one to many
        public Category Category { get; set; }
        public ICollection<Order> Order { get; set; }
        public IList<Product_Order> Product_Orders { get; set; }//many to many

    }
}
