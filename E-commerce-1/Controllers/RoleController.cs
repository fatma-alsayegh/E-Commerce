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
    public class RoleController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public RoleController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
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

