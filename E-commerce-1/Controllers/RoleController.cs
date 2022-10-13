using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public RoleController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }

        [HttpGet]
        public IActionResult GetRole(int id)
        {
            var Role = _eCommerceContext.Roles.Where(x => x.Id == id);
            if (Role != null)
            {
                return Ok(Role);
            }
            else
            {
                return null;
            }
        }
    }
}

