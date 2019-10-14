using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPagesDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazorPagesDemo.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _context.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var bookFromDb = await _context.Book.FindAsync(id);
            if(bookFromDb == null)
            {
                return NotFound();
            }
            _context.Book.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}