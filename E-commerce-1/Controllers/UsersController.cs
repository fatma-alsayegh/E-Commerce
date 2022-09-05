using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace E_commerce_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private static User[] users = new User[]
        {
           new User{
                Username="admin",
                Password="123",
                Email="admin@emaratech.ae",
                FirstName="Admin",
                LastName="Admin",
                Country="UAE",
                City="Sharjah",
            },
            new User{
                Username="fatma",
                Password="123",
                Email="fatma@emaratech.ae",
                FirstName="Fatma",
                LastName="AlSayegh",
                Country="UAE",
                City="Dubai",
            }
        };

        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

      

        [HttpGet]
        public User Get(string username, string password)
        {
            var user = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
              
                return user;
            }
            else
            {
                return null;
            }

        }


    }
}
