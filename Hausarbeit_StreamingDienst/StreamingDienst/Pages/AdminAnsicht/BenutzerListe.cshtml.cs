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
    public class BenutzerListeModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public BenutzerListeModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        [BindProperty]
        public User Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? AdminID)
        {
            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            User = await _context.User.ToListAsync();
            return Page();
        }
    }
}
