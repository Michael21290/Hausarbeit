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
    public class FolgeAnsehenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FolgeAnsehenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serie Serie { get; set; }

        [BindProperty]
        public Folge Folge { get; set; }

        public string FolgenData { get; set; }

        [BindProperty]
        public User User { get; set; }

        public List<string> VideoData { get; set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int? FolgenID, int? SerienID, int? UserID)
        {
            Serie = await _context.Serie.FirstOrDefaultAsync(x => x.ID == SerienID);
            User = await _context.User.FirstOrDefaultAsync(x => x.ID == UserID);
            Folge = await _context.Folge.FirstOrDefaultAsync(x => x.ID == FolgenID && x.FSerienID.ID == SerienID);

            string VideoBase64Data = Convert.ToBase64String(Folge.VideoData);
            FolgenData = string.Format("data:Video/webm;base64,{0}", VideoBase64Data);

            return Page();
        }
    }
}
