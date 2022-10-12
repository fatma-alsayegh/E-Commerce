using E_commerce_1;
using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_1_API.Controllers
{
    [Route("[controller]")]
    public class UserRoleController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public UserRoleController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
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

