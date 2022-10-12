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
    public class ProductController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public ProductController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
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


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] Product product)
        {
            //var _product = _eCommerceContext.Products.Where(x => x.Name == product.Name);
            //if (!_product.Any())
            //{
                //var file = Request.Form.Files[0];
                //var folderName = Path.Combine(@"wwwroot\Product Images", file.FileName);
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                //product.Icon = pathToSave;
                //if (file.Length > 0)
                //{
                //    using (var stream = new FileStream(pathToSave, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //    product.Icon = pathToSave;
                    _eCommerceContext.Products.Add(product);
                    await _eCommerceContext.SaveChangesAsync();
                    return Ok(product);
                //}
                //else
                //{
                //    return null;
                //}
            
            //else
            //{
            //    return null;
            //}

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var _product = _eCommerceContext.Products.Find(product.Id);
            if (_product != null)
            {
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.Price = product.Price;
                _product.CategoryId = product.CategoryId;
                await _eCommerceContext.SaveChangesAsync();
                return Ok(_product);
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
