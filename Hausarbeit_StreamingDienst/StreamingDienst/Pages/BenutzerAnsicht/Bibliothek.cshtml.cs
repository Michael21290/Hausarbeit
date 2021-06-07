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
    public class BibliothekModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public BibliothekModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Film> Filme { get; set; }

        [BindProperty]
        public List<Genre> Genre { get; set; }

        [BindProperty]
        public IList<Serie> Serien { get; set; }

        [BindProperty]
        public IList<UserFilm> UserFilm { get; set; }

        [BindProperty]
        public IList<UserFilm> UserSerie { get; set; }

        [BindProperty]
        public User User { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SucheGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Suche { get; set; }

        public SelectList GenreListe { get; set; }

        public async Task<IActionResult> OnPostAsync(int UserID)
        {
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserID);
            Serien = await _context.Serie.ToListAsync();
            Filme = await _context.Film.ToListAsync();
            Genre = await _context.Genre.ToListAsync();
            GenreListe = new SelectList(Genre.Select(x => x.GenreName).Distinct().ToList());
            UserFilm = await _context.UserFilm.Where(x => x.FUserID.ID == UserID && x.UFilmID != null).ToListAsync();
            UserSerie = await _context.UserFilm.Where(x => x.FUserID.ID == UserID && x.USerienID != null).ToListAsync();

            if (!string.IsNullOrEmpty(SucheGenre))
            {
                UserFilm = UserFilm.Where(x => x.UFilmID != null && x.UFilmID.FGenreID.GenreName.Contains(SucheGenre)).ToList();
                UserSerie = UserSerie.Where(x => x.USerienID != null && x.USerienID.SGenreID.GenreName.Contains(SucheGenre)).ToList();
            }       

            if (!string.IsNullOrEmpty(Suche))
            {
                UserFilm = UserFilm.Where(x =>x.UFilmID.FilmTitel.ToLower().Contains(Suche.ToLower())).ToList();
                UserSerie = UserSerie.Where(x => x.USerienID.SerienTitel.ToLower().Contains(Suche.ToLower())).ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnGetAsync(int UserID)
        {
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserID);
            Serien = await _context.Serie.ToListAsync();
            Filme = await _context.Film.ToListAsync();
            Genre = await _context.Genre.ToListAsync();
            GenreListe = new SelectList(Genre.Select(x => x.GenreName).Distinct().ToList());
            UserFilm = await _context.UserFilm.Where(x => x.FUserID.ID == UserID && x.UFilmID != null).ToListAsync();
            UserSerie = await _context.UserFilm.Where(x => x.FUserID.ID == UserID && x.USerienID != null).ToListAsync();

            //if (!string.IsNullOrEmpty(SucheGenre))
            //{
            //    UserFilm = UserFilm.Where(x => x.UFilmID.FGenreID.GenreName.ToLower().Contains(SucheGenre.ToLower())).ToList();
            //    UserSerie = UserFilm.Where(x => x.USerienID.SGenreID.GenreName.ToLower().Contains(SucheGenre.ToLower())).ToList();
            //}

            return Page();
        }
    }
}
