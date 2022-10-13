using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_1
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
