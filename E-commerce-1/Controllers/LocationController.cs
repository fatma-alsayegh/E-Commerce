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
    public class LocationController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public LocationController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetLocation(int id)
        {
            var location = _eCommerceContext.Locations.Where(x => x.Id == id);
            if (location != null)
            {

                return Ok(location);
            }
            else
            {
                return null;
            }
        }



    }
}



