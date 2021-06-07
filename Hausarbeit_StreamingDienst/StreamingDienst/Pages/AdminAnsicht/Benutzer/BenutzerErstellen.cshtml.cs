using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Modelle;
using StreamingDienst.Data;
using System.Security.Cryptography;
using System.Diagnostics;

namespace StreamingDienst.Pages.AdminAnsicht
{
    public class BenutzerErstellenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public BenutzerErstellenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public IList<User> UserList { get; set; }

        [BindProperty]
        public string Wiederholung { get; set; }

        public bool Vorhanden { get; set; } = false;

        public class SaltAndHash
        {
            public string salt { get; set; }

            public string hash { get; set; }

            public SaltAndHash(string salt, string hash)
            {
                this.salt = salt;
                this.hash = hash;
            }
        }

        private static int numberOfIterations = 10000;

        public IActionResult OnGet(int? AdminID)
        {
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int AdminID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);

            UserList = _context.User.ToList();

            if (UserList.Any(x => x.Benutzername == User.Benutzername))
            {
                Vorhanden = true;
            }

            if (Vorhanden)
            {
                ViewData["error"] = "Der Benutzername ist bereits vorhanden.";
                return Page();
            }
            else if (User.Hash != Wiederholung)
            {
                ViewData["error"] = "Passwort stimmt nicht überein.";
                return Page();
            }
            else
            {
                SaltAndHash sh = GenerateSaltAndHash(User.Hash);
                
                SaltAndHash GenerateSaltAndHash(string password)
                {
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32);
                    rfc2898DeriveBytes.IterationCount = numberOfIterations;
                    byte[] hash = rfc2898DeriveBytes.GetBytes(20);
                    byte[] salt = rfc2898DeriveBytes.Salt;

                    string saltString = Convert.ToBase64String(salt);
                    string passwordHash = Convert.ToBase64String(hash);
                    return new SaltAndHash(saltString, passwordHash);
                }

                User.Hash = sh.hash;
                User.Salt = sh.salt;

                _context.User.Add(User);
                await _context.SaveChangesAsync();

                return RedirectToPage("../BenutzerListe", new { AdminID = Admin.ID });
            }     
        }
    }
}
