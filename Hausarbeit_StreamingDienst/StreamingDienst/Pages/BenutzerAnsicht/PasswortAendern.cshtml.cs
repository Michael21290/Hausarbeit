using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamingDienst.Modelle;
using StreamingDienst.Data;
using System.Security.Cryptography;
using System.Diagnostics;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class PasswortAendernModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public PasswortAendernModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

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

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public string AltesPasswort { get; set; }

        [BindProperty]
        public string NeuesPasswort { get; set; }

        [BindProperty]
        public string PasswortWiederholen { get; set; }

        private static readonly int numberOfIterations = 10000;

        public async Task<IActionResult> OnGetAsync(int UserID)
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

        public async Task<IActionResult> OnPostAsync(int UserID)
        {
            User = _context.User.FirstOrDefault(x => x.ID == UserID);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!CheckPassword(User.Benutzername, AltesPasswort))
            {
                ViewData["error"] = "Falsches Passwort!";
                return Page();
            }
            else if (NeuesPasswort != PasswortWiederholen)
            {
                ViewData["error"] = "Neues Passwort stimmt nicht überein!";
                return Page();
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                SaltAndHash sh = GenerateSaltAndHash(NeuesPasswort);
                sw.Stop();

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

                _context.Attach(User).State = EntityState.Modified;
                await _context.SaveChangesAsync();              
            }

            return RedirectToPage("../Index");

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
