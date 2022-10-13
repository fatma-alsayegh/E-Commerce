using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_1
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int LocationId { get; set; }//one to many
        public Location Location { get; set; }
        public IList<User_Role> User_Roles { get; set; }//many to many
        public ICollection<Order> Orders { get; set; }
    }
}
