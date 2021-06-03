using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht.Filme
{
    public class FilmHinzufuegenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FilmHinzufuegenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Film Film { get; set; }

        [BindProperty]
        public Modelle.Genre Genre { get; set; }

        public IList<Modelle.Genre> GenreListe { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty]
        public string GenreWahl { get; set; }

        [BindProperty]
        public string LaengeText { get; set; }

        [BindProperty]
        public string KaufpreisText { get; set; }

        [BindProperty]
        public string LeihpreisText { get; set; }

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

            if (Decimal.TryParse(LaengeText, out decimal Laenge) &&
                Decimal.TryParse(LaengeText, out decimal Kaufpreis) &&
                Decimal.TryParse(LaengeText, out decimal Leihpreis))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Upload.CopyToAsync(memoryStream);

                    var film = new Film()
                    {
                        VideoData = memoryStream.ToArray(),
                        FilmTitel = Upload.FileName.Replace(".mp4", ""),
                        FilmLaenge = Laenge,
                        Leihpreis = Leihpreis,
                        Kaufpreis = Kaufpreis,
                        FGenreID = Genre
                    };

                    _context.Film.Add(film);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("../FilmListe", new { AdminID = Admin.ID });
            }
            else
            {
                ViewData["error"] = "Bitte geben Sie einen gültige Zahlen ein.";
                ViewData["bsp"] = "Bsp: \"5,99\".";
                return Page();
            }
        }
    }
}
