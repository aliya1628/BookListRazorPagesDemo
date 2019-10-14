using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazorPagesDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazorPagesDemo.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _context.Book.FindAsync(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await _context.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.Author = Book.Author;
                bookFromDb.ISBM = Book.ISBM;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}