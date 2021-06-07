using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingDienst.Data;
using StreamingDienst.Modelle;

namespace StreamingDienst.Pages.AdminAnsicht.Folgen
{
    public class FolgeHinzufuegenModel : PageModel
    {
        private readonly StreamingDienst.Data.StreamingDienstContext _context;

        public FolgeHinzufuegenModel(StreamingDienst.Data.StreamingDienstContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User Admin { get; set; }

        [BindProperty]
        public Serie Serie { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public Folge Folge { get; set; }

        [BindProperty]
        public string LaengeText { get; set; }

        [BindProperty]
        public string KaufpreisText { get; set; }

        [BindProperty]
        public string LeihpreisText { get; set; }

        public IActionResult OnGet(int? SerienID, int? AdminID)
        {
            Serie = _context.Serie.FirstOrDefault(x => x.ID == SerienID);
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? SerienID, int? AdminID)
        {
            Serie = _context.Serie.FirstOrDefault(x => x.ID == SerienID);
            Admin = _context.User.FirstOrDefault(x => x.ID == AdminID);

            if (Decimal.TryParse(KaufpreisText, out decimal Kaufpreis) && 
                Decimal.TryParse(LeihpreisText, out decimal Leihpreis))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Upload.CopyToAsync(memoryStream);

                    var folge = new Folge()
                    {
                        VideoData = memoryStream.ToArray(),
                        FolgenTitel = Upload.FileName.Replace(".mp4", ""),
                        FolgenLaenge = Folge.FolgenLaenge,
                        Kaufpreis = Kaufpreis,
                        Leihpreis = Kaufpreis,
                        FSerienID = Serie
                    };

                    _context.Folge.Add(folge);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("../FolgenListe", new { AdminID = Admin.ID, SerienID = Serie.ID });
            }
            else
            {
                ViewData["error"] = "Bitte geben Sie einen gültige Betrag ein.";
                ViewData["bsp"] = "Bsp: \"5,99\".";
                return Page();
            }   
        }
    }
}
