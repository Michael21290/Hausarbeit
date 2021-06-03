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
    public class IndexModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public IndexModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get;set; }

        public IActionResult OnGet(int? AdminID)
        {
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            return Page();
        }
    }
}
