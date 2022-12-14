using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_1
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
