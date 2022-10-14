using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public ProductController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int id)
        {
            // var product = await _eCommerceContext.Products.ToListAsync();
            if (id == 0)
            {
                var product = await _eCommerceContext.Products.ToListAsync();
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return null;
                }
            }
            else {
                var product = await _eCommerceContext.Products.FindAsync(id);
                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return null;
                }
            }
            
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOneProduct([FromBody]int id)
        //{
        //    var product = await _eCommerceContext.Products.FindAsync(id);

        //    //var product = await _eCommerceContext.Products.ToListAsync();
        //    if (product != null)
        //    {
        //        return Ok(product);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] Product product)
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine(@"wwwroot\Product Images", file.FileName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(pathToSave, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                product.Icon = $"/Product Images/{file.FileName}";
                _eCommerceContext.Products.Add(product);
                await _eCommerceContext.SaveChangesAsync();
                return Ok(product);
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] Product product)
        {
            var _product = _eCommerceContext.Products.Find(product.Id);
            if (_product != null)
            {
                if (product.Icon.StartsWith("/Product Images/"))
                {
                    _product.Name = product.Name;
                    _product.Description = product.Description;
                    await _eCommerceContext.SaveChangesAsync();
                    return Ok(_product);
                }
                else
                {
                    var file = Request.Form.Files[0];
                    var folderName = Path.Combine(@"wwwroot\Product Images", file.FileName);
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        using (var stream = new FileStream(pathToSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        _product.Icon = $"/Product Images/{file.FileName}";
                        _product.Name = product.Name;
                        _product.Description = product.Description;
                        await _eCommerceContext.SaveChangesAsync();
                        return Ok(_product);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var _product = await _eCommerceContext.Products.FindAsync(id);
            if (_product != null)
            {
                _eCommerceContext.Products.Remove(_product);
                await _eCommerceContext.SaveChangesAsync();
                return Ok(_product);
            }
            else
            {
                return null;
            }
        }
    }
}
