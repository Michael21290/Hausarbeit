using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class FilmAnsehenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FilmAnsehenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; }

        public string FilmData { get; set; }

        [BindProperty]
        public User User { get; set; }

        public List<string> VideoData { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int? FilmID, int? UserID)
        {
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserID);
            Film = await _context.Film.FirstOrDefaultAsync(x => x.ID == FilmID);

            string VideoBase64Data = Convert.ToBase64String(Film.VideoData);
            FilmData = string.Format("data:Video/webm;base64,{0}", VideoBase64Data);

            return Page();
        }
    }
}
