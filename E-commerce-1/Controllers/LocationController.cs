using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public LocationController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
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



