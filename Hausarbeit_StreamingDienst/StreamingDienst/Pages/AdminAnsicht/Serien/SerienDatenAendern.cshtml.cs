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

namespace StreamingDienst.Pages.AdminAnsicht.Serien
{
    public class SerienDatenAendernModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public SerienDatenAendernModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serie Serie { get; set; }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public Modelle.Genre Genre { get; set; }

        public IList<Modelle.Genre> GenreListe { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty]
        public string GenreWahl { get; set; }

        public async Task<IActionResult> OnGetAsync(int? SerienID, int? AdminID)
        {
            if (SerienID == null)
            {
                return NotFound();
            }

            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            Serie = await _context.Serie.FirstOrDefaultAsync(m => m.ID == SerienID);
            GenreListe = _context.Genre.ToList();
            Genres = new SelectList(GenreListe.Select(x => x.GenreName).Distinct().ToList());

            if (Serie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            GenreListe = _context.Genre.ToList();
            Genre = GenreListe.FirstOrDefault(x => x.GenreName == GenreWahl);

            Serie.SGenreID = Genre;

            _context.Attach(Serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(Serie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../SerienListe", new { AdminID = Admin.ID});
        }

        private bool SerieExists(int SerienID)
        {
            return _context.Serie.Any(e => e.ID == SerienID);
        }
    }
}
