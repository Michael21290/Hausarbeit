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

namespace StreamingDienst.Pages.AdminAnsicht
{
    public class SperrenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public SperrenModel(StreamingDienst.Data.StreamingDienstContext context)
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

            Admin = _context.User.FirstOrDefault(m => m.ID == AdminID);
            User = await _context.User.FirstOrDefaultAsync(m => m.ID == UserID);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin = _context.User.FirstOrDefault(m => m.ID == AdminID);
            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../BenutzerListe", new { AdminID = Admin.ID});
        }

        private bool UserExists(int UserID)
        {
            return _context.User.Any(e => e.ID == UserID);
        }
    }
}
