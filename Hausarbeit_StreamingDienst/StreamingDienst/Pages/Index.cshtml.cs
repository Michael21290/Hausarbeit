using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StreamingDienst.Modelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StreamingDienst.Pages
{
    public class IndexModel : PageModel
    {

        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public IndexModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public bool Gesperrt { get; set; }

        [BindProperty]
        public string Benutzername { get; set; }
        [BindProperty]
        public string Passwort { get; set; }
        public int UserID { get; set; }

        private static readonly int numberOfIterations = 10000;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            User = await _context.User.FirstOrDefaultAsync(m => m.Benutzername == Benutzername);
            Gesperrt = _context.User.FirstOrDefault(m => m.Benutzername == Benutzername).Gesperrt;

            if (CheckPassword(Benutzername, Passwort))
            {
                if(User.Admin)
                {
                    return RedirectToPage("./AdminAnsicht/Index", new { AdminID = User.ID });
                }
                else
                {
                    return RedirectToPage("./BenutzerAnsicht/Index", new { UserID = User.ID });
                }
            }
            else
            {
                ViewData["error"] = "Falscher Benutzername oder Passwort!";
                return Page();
            }

            bool CheckPassword(string userName, string password)
            {
                string salt = GetSaltFromDB(userName);

                if (salt == null)
                {
                    return false;
                }

                byte[] saltBytes = Convert.FromBase64String(salt);

                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes);
                rfc2898DeriveBytes.IterationCount = numberOfIterations;
                byte[] enteredHash = rfc2898DeriveBytes.GetBytes(20);
                string str = Convert.ToBase64String(enteredHash);
                string expectedHash = GetHashFromDB(userName);

                bool hashesMatch = str.Equals(expectedHash);
                return hashesMatch;
            }

            string GetHashFromDB(string userName)
            {
                if (User != null)
                {
                    return User.Hash;
                }
                return null;
            }

            string GetSaltFromDB(string userName)
            {
                if (User != null)
                {
                    return User.Salt;
                }
                return null;
            }
        }
    }
}