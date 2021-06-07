using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht.Genre
{
    public class GenreAendernModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public GenreAendernModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modelle.Genre Genre { get; set; }

        [BindProperty]
        public User Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? GenreID, int AdminID)
        {
            if (GenreID == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.FirstOrDefaultAsync(m => m.ID == GenreID);
            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            _context.Attach(Genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(Genre.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../GenreListe", new { AdminID = Admin.ID });
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.ID == id);
        }
    }
}
