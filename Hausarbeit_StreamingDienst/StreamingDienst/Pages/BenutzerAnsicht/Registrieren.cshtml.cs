using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.BenutzerAnsicht
{
    public class RegistrierenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public RegistrierenModel(StreamingDienst.Data.StreamingDienstContext context)
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
        public IList<User> UserList { get; set; }


        public bool Vorhanden { get; set; } = false;

        private static int numberOfIterations = 10000;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserList = _context.User.ToList();

            if(UserList.Any(x => x.Benutzername == User.Benutzername))
            {
                Vorhanden = true;
            }
            
            if(Vorhanden)
            {
                ViewData["error"] = "Der Benutzername ist bereits vorhanden.";
                return Page();
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                SaltAndHash sh = GenerateSaltAndHash(User.Hash);
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

                _context.User.Add(User);
                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
            
        }
    }
}
