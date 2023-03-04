using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRozar.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRozar.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContest _db;
        public CreateModel(AppDbContest db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("IndexBook");
            }
            else
            {
                return Page();
            }
        }
    }
}
