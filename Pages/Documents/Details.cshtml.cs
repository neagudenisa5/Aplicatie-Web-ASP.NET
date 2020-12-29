using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeaguDenisa_Proiect.Data;
using NeaguDenisa_Proiect.Models;

namespace NeaguDenisa_Proiect.Pages.Documents
{
    public class DetailsModel : PageModel
    {
        private readonly NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext _context;

        public DetailsModel(NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext context)
        {
            _context = context;
        }

        public Document Document { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Document = await _context.Document.FirstOrDefaultAsync(m => m.ID == id);

            if (Document == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
