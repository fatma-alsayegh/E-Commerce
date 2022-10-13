using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class ProductOrderController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public ProductOrderController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsInCart()
        {
            var product_orders = await _eCommerceContext.Product_Orders.ToListAsync();
            if (product_orders != null)
            {
                return Ok(product_orders);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductInOrder([FromBody] Product_Order product_order)
        {
            _eCommerceContext.Product_Orders.Add(product_order);
            await _eCommerceContext.SaveChangesAsync();
            return Ok(product_order);
        }
    }
}
