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
    public class GutschriftModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public GutschriftModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public static decimal AltesGuthaben { get; set; }

        [BindProperty]
        public string GuthabenText { get; set; }

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
            AltesGuthaben = User.Guthaben;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Decimal.TryParse(GuthabenText, out decimal GuthabenHinzufuegen))
            {
                User.Guthaben = AltesGuthaben + Convert.ToDecimal(GuthabenHinzufuegen);
                _context.Attach(User).State = EntityState.Modified;
            }
            else
            {
                ViewData["error"] = "Bitte geben Sie einen gültigen Betrag ein.";
                ViewData["bsp"] = "Bsp: \"5,99\".";
                return Page();
            }

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

            return RedirectToPage("../BenutzerListe", new { AdminID = Admin.ID });
        }

        private bool UserExists(int UserID)
        {
            return _context.User.Any(e => e.ID == UserID);
        }
    }
}
