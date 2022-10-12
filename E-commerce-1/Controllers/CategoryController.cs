using E_commerce_1;
using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_1_API.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;

        public CategoryController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _eCommerceContext.Categories.ToListAsync();
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] Category category)
        {


            var _category = _eCommerceContext.Categories.Where(x => x.Name == category.Name);
            if (!_category.Any())
            {
                //var file = Request.Form.Files[0];
                //var folderName = Path.Combine(@"wwwroot\Category Images", file.FileName);
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                //category.Icon = pathToSave;
                //if (file.Length > 0)
                //{
                //    using (var stream = new FileStream(pathToSave, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //    category.Icon = pathToSave;
                    _eCommerceContext.Categories.Add(category);
                    await _eCommerceContext.SaveChangesAsync();
                    return Ok(category);
                //}
                //else
                //{
                //    return null;
                //}
            }
            else
                {
                    return null;
                }
            }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            var _category = _eCommerceContext.Categories.Find(category.Id);
            if (_category != null)
            {
                _category.Name = category.Name;
                _category.Description = category.Description;
                await _eCommerceContext.SaveChangesAsync();
                return Ok(_category);
            }
            else
            {
                return null;
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var _category = await _eCommerceContext.Categories.FindAsync(id);
            if (_category != null)
            {
                _eCommerceContext.Categories.Remove(_category);
                await _eCommerceContext.SaveChangesAsync();
                return Ok(_category);
            }
            else
            {
                return null;
            }
        }
    }
}

