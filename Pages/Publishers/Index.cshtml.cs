using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NeaguDenisa_Proiect.Data;
using NeaguDenisa_Proiect.Models;

namespace NeaguDenisa_Proiect.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext _context;

        public IndexModel(NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
