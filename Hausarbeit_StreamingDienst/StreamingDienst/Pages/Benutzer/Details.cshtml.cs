using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;
using StreamingDienst.Data;

namespace StreamingDienst.Pages.Benutzer
{
    public class DetailsModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public DetailsModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
