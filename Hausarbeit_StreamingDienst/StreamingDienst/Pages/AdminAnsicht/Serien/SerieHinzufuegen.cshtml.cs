using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht.Serien
{
    public class SerieHinzufuegenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public SerieHinzufuegenModel(StreamingDienst.Data.StreamingDienstContext context)
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

        public IActionResult OnGet(int? AdminID)
        {
            GenreListe = _context.Genre.ToList();
            Genres = new SelectList(GenreListe.Select(x => x.GenreName).Distinct().ToList());
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            GenreListe = _context.Genre.ToList();
            Genre = GenreListe.FirstOrDefault(x => x.GenreName == GenreWahl);

            var serie = new Serie()
            {
                SerienTitel = Serie.SerienTitel,
                AnzahlFolgen = Serie.AnzahlFolgen,
                SGenreID = Genre
            };
        
            _context.Serie.Add(serie);
            await _context.SaveChangesAsync();

            return RedirectToPage("../SerienListe", new { AdminID = Admin.ID });
        }
    }
}
