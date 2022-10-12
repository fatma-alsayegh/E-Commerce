using E_commerce_1.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public OrderController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _eCommerceContext.Orders.ToListAsync();
            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return null;
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {

            _eCommerceContext.Orders.Add(order);
            await _eCommerceContext.SaveChangesAsync();
            return Ok(order);
        }
    }
}
