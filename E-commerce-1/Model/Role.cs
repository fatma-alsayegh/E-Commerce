using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_1
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<User_Role> User_Roles { get; set; }//many to many
    }
}
