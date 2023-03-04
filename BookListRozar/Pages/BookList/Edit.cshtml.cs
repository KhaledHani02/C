using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRozar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRozar.Pages.BookList
{
    public class EditModel : PageModel
    {
        private AppDbContest _db;
        public EditModel(AppDbContest db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int ID)
        {
            Book = await _db.Book.FindAsync(ID); 
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN= Book.ISBN;
                BookFromDb.Author = Book.Author;
                await _db.SaveChangesAsync();
                return RedirectToPage("IndexBook");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
