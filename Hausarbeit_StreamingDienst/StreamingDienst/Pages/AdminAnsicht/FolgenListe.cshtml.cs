using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht
{
    public class FolgenListeModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FolgenListeModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public IList<Folge> Folge { get;set; }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public Serie Serie { get; set; }

        public async Task OnGetAsync(int? SerienID, int? AdminID)
        {
            Serie = await _context.Serie.FirstOrDefaultAsync(x => x.ID == SerienID);
            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            Folge = await _context.Folge.Where(x => x.FSerienID.ID == SerienID).ToListAsync();
        }
    }
}
