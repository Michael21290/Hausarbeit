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

namespace StreamingDienst.Pages.AdminAnsicht
{
    public class AccountdatenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public AccountdatenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public User Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int AdminID)
        {
            Admin = await _context.User.FirstOrDefaultAsync(m => m.ID == AdminID);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
