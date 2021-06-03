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
    public class SerienVerleihModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public SerienVerleihModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int UserID, int SerienID)
        {
            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            Serie = _context.Serie.FirstOrDefault(x => x.ID == SerienID);
            Folgen = _context.Folge.ToList();

            foreach (var Folge in Folgen.Where(x => x.FSerienID.ID == SerienID))
            {
                Leihpreis += Folge.Leihpreis;
            }

            NeuesGuthaben = User.Guthaben - Leihpreis;
            return Page();
        }

        [BindProperty]
        public UserFilm UserFilm { get; set; }

        [BindProperty]
        public IList<UserFilm> UserFilmListe { get; set; }

        [BindProperty]
        public Serie Serie { get; set; }

        [BindProperty]
        public User User { get; set; }

        public IList<Folge> Folgen { get; set; }

        [BindProperty]
        public decimal NeuesGuthaben { get; set; }

        [BindProperty]
        public decimal Leihpreis { get; set; } = 0;

        public bool Vorhanden { get; set; } = false;

        public async Task<IActionResult> OnPostAsync(int UserID, int SerienID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            Serie = _context.Serie.FirstOrDefault(x => x.ID == SerienID);
            Folgen = _context.Folge.ToList();
            UserFilmListe = _context.UserFilm.Where(x => x.USerienID != null && x.FUserID.ID == UserID).ToList();

            foreach(var userFilm in UserFilmListe)
            {
                if(userFilm.USerienID.ID == SerienID && userFilm.FUserID.ID == UserID)
                {
                    Vorhanden = true;
                }
            }

            foreach (var Folge in Folgen.Where(x => x.FSerienID.ID == SerienID))
            {
                Leihpreis += Folge.Leihpreis;
            }

            NeuesGuthaben = User.Guthaben - Leihpreis;

            if (NeuesGuthaben < 0)
            {
                ViewData["error"] = "Ihr Guthaben reicht leider nicht aus.";
                return Page();
            }
            else if(!Vorhanden)
            {
                UserFilm.FUserID = User;
                UserFilm.USerienID = Serie;
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
