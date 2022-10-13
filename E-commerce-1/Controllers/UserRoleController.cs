using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class UserRoleController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public UserRoleController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }

        [HttpGet]
        public IActionResult GetUserRole(int id)
        {
            var userRole = _eCommerceContext.User_Roles.Where(x => x.UserId == id);

            if (userRole != null)
            {
                return Ok(userRole);
            }
            else
            {
                return null;
            }
        }
    }
}

