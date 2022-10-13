using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_commerce_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public UsersController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }

        [HttpGet]
        public IActionResult GetUser(string email, string password)
        {
            var user = _eCommerceContext.Users.Where(x => x.Email == email && x.Password == password);

            if (user.Any())
            {
                return Ok(user);
            }
            else
            {
                return null;
            }
        }
    }
}
