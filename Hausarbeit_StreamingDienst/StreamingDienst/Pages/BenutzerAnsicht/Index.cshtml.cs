using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;
using StreamingDienst.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class IndexModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public IndexModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public List<Genre> Genre { get; set; }

        public IList<Film> Film { get; set; }

        public IList<Serie> Serien { get; set; }

        public IList<Folge> Folgen { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SucheGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Suche { get; set; }

        public SelectList GenreListe { get; set; }

        public Dictionary<int, decimal> KaufPreisListe = new Dictionary<int, decimal>();
        public Dictionary<int, decimal> LeihPreisListe = new Dictionary<int, decimal>();

        public async Task<IActionResult> OnPostAsync(int UserID)
        {
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserID);
            Genre = await _context.Genre.ToListAsync();
            Serien = await _context.Serie.ToListAsync();
            Folgen = await _context.Folge.ToListAsync();
            Film = await _context.Film.ToListAsync();
            GenreListe = new SelectList(Genre.Select(x => x.GenreName).Distinct().ToList());

            if (!string.IsNullOrEmpty(SucheGenre))
            {
                Film = Film.Where(x => x.FGenreID.GenreName.ToLower().Contains(SucheGenre.ToLower())).ToList();
                Serien = Serien.Where(x => x.SGenreID.GenreName.ToLower().Contains(SucheGenre.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(Suche))
            {
                Film = Film.Where(x => x.FilmTitel.ToLower().Contains(Suche.ToLower())).ToList();
                Serien = Serien.Where(x => x.SerienTitel.ToLower().Contains(Suche.ToLower())).ToList();
            }

            foreach (var Serie in Serien)
            {
                decimal Kaufpreis = 0;
                decimal Leihpreis = 0;
                foreach (var Folge in Folgen.Where(x => x.FSerienID.ID == Serie.ID))
                {
                    Kaufpreis += Folge.Kaufpreis;
                    Leihpreis += Folge.Leihpreis;
                }
                KaufPreisListe.Add(Serie.ID, Kaufpreis);
                LeihPreisListe.Add(Serie.ID, Leihpreis);
            }

            return Page();
        }

        public IActionResult OnGet(int UserID)
        {
            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            Genre = _context.Genre.ToList();
            Serien = _context.Serie.ToList();
            Folgen = _context.Folge.ToList();
            Film = _context.Film.ToList();
            GenreListe = new SelectList(Genre.Select(x => x.GenreName).Distinct().ToList());

            foreach (var Serie in Serien)
            {
                decimal Kaufpreis = 0;
                decimal Leihpreis = 0;
                foreach(var Folge in Folgen.Where(x => x.FSerienID.ID == Serie.ID))
                {
                    Kaufpreis += Folge.Kaufpreis;
                    Leihpreis += Folge.Leihpreis;
                }
                KaufPreisListe.Add(Serie.ID, Kaufpreis);
                LeihPreisListe.Add(Serie.ID, Leihpreis);
            }
            
            return Page();
        }
    }
}
