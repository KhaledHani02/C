using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRozar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRozar.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private AppDbContest _db;
        public UpsertModel(AppDbContest db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? ID)
        {
            Book = new Book();
            if (ID==null)
            {
                return Page();
            }
            Book = await _db.Book.FirstOrDefaultAsync(u=>u.Id==ID);
            if (Book==null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id==0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book);
                }
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
