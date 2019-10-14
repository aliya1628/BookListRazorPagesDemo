using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPagesDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorPagesDemo.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _context.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if(bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting.." });
            }
            else
            {
                _context.Book.Remove(bookFromDb);
                await _context.SaveChangesAsync();
                return Json(new { success = true , message = "Deleted successfully.."});
            }
            
        }
    }
}