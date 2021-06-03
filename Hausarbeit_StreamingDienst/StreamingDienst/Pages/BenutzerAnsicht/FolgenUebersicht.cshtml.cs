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
    public class FolgenUebersichtModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FolgenUebersichtModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public IList<Folge> Folge { get; set; }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public Serie Serie { get; set; }

        public async Task OnGetAsync(int? SerienID, int? UserId)
        {
            Serie = await _context.Serie.FirstOrDefaultAsync(x => x.ID == SerienID);
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserId);
            Folge = await _context.Folge.Where(x => x.FSerienID.ID == SerienID).ToListAsync();
        }
    }
}
