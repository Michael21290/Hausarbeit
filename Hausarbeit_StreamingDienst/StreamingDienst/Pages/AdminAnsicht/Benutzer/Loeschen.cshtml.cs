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
    public class LoeschenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public LoeschenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public User Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? UserID, int? AdminID)
        {
            if (UserID == null)
            {
                return NotFound();
            }

            Admin = await _context.User.FirstOrDefaultAsync(m => m.ID == AdminID);
            User = await _context.User.FirstOrDefaultAsync(m => m.ID == UserID);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? UserID, int? AdminID)
        {
            if (UserID == null)
            {
                return NotFound();
            }

            Admin = await _context.User.FirstOrDefaultAsync(m => m.ID == AdminID);
            User = await _context.User.FindAsync(UserID);

            if (User != null)
            {
                _context.User.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../BenutzerListe", new { AdminID = Admin.ID});
        }
    }
}
