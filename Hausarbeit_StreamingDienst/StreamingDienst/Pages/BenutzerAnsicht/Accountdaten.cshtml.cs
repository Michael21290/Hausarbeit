using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;
using StreamingDienst.Data;
using System.Globalization;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class AccountdatenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public AccountdatenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == UserID);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
