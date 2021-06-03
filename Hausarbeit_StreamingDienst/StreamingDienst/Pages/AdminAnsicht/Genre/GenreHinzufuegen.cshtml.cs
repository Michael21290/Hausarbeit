using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht.Genre
{
    public class GenreHinzufuegenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public GenreHinzufuegenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get; set; }

        public IActionResult OnGet(int? AdminID)
        {
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            return Page();
        }

        [BindProperty]
        public Modelle.Genre Genre { get; set; }

        public async Task<IActionResult> OnPostAsync(int? AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);

            _context.Genre.Add(Genre);
            await _context.SaveChangesAsync();

            return RedirectToPage("../GenreListe", new { AdminID = Admin.ID});
        }
    }
}
