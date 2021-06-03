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

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class FilmVerleihModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FilmVerleihModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int UserID, int FilmID)
        {
            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            Film = _context.Film.FirstOrDefault(x => x.ID == FilmID);

            NeuesGuthaben = User.Guthaben - Film.Leihpreis;
            return Page();
        }

        [BindProperty]
        public UserFilm UserFilm { get; set; }

        [BindProperty]
        public IList<UserFilm> UserFilmListe { get; set; }

        [BindProperty]
        public Film Film { get; set; }

        [BindProperty]
        public IList<Film> FilmListe { get; set; }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public decimal NeuesGuthaben { get; set; }

        public bool Vorhanden { get; set; } = false;

        public async Task<IActionResult> OnPostAsync(int UserID, int FilmID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FilmListe = _context.Film.ToList();
            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            Film = _context.Film.FirstOrDefault(x => x.ID == FilmID);
            UserFilmListe = _context.UserFilm.Where(x => x.UFilmID != null && x.FUserID.ID == UserID).ToList();

            foreach (var userFilm in UserFilmListe)
            {
                if (userFilm.UFilmID.ID == FilmID && userFilm.FUserID.ID == UserID)
                {
                    Vorhanden = true;
                }
            }

            NeuesGuthaben = User.Guthaben - Film.Leihpreis;

            if (NeuesGuthaben < 0)
            {
                ViewData["error"] = "Ihr Guthaben reicht leider nicht aus.";
                return Page();
            }
            else if (!Vorhanden)
            {
                UserFilm.FUserID = User;
                UserFilm.UFilmID = Film;
                UserFilm.LeihDatum = DateTime.Now;
                User.Guthaben = NeuesGuthaben;

                _context.Attach(User).State = EntityState.Modified;
                _context.UserFilm.Add(UserFilm);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index", new { UserID = User.ID });
            }
            else
            {
                ViewData["error"] = "Der Titel ist bereits ausgeliehen oder gekauft.";
                return Page();
            }

            
        }
    }
}
