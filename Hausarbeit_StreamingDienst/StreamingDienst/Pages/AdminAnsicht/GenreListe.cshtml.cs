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
    public class GenreListeModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public GenreListeModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get; set; }

        public IList<Modelle.Genre> Genre { get;set; }

        public async Task OnGetAsync(int? AdminID)
        {
            Admin = await _context.User.FirstOrDefaultAsync(x => x.ID == AdminID);
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
