using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;
using StreamingDienst.Data;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class AccountLoeschenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public AccountLoeschenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }

            User = await _context.User.FindAsync(UserID);

            if (User != null)
            {
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
