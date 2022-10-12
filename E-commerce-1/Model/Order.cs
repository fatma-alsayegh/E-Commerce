using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_1
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrderNumber { get; set; }
        public int ProductCount { get; set; }
        public string TotalCost { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
        public IList<Product_Order> Product_Orders { get; set; }//many to many

    }
}
