using E_commerce_1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace E_commerce_1.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ECommerceContext _eCommerceContext;
        public CategoryController(ECommerceContext eCommerceContext)
        {
            this._eCommerceContext = eCommerceContext;
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
            var file = Request.Form.Files[0];
            var folderName = Path.Combine(@"wwwroot\Category Images", file.FileName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(pathToSave, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                category.Icon = $"/Category Images/{file.FileName}";
                _eCommerceContext.Categories.Add(category);
                await _eCommerceContext.SaveChangesAsync();
                return Ok(category);
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] Category category)
        {
            var _category = _eCommerceContext.Categories.Find(category.Id);
            if (_category != null)
            {
                if (category.Icon.StartsWith("/Category Images/"))
                {
                    _category.Name = category.Name;
                    _category.Description = category.Description;
                    await _eCommerceContext.SaveChangesAsync();
                    return Ok(_category);
                }
                else
                {
                    var file = Request.Form.Files[0];
                    var folderName = Path.Combine(@"wwwroot\Category Images", file.FileName);
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        using (var stream = new FileStream(pathToSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        _category.Icon = $"/Category Images/{file.FileName}";
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
