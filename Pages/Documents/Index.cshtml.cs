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
    public class IndexModel : PageModel
    {
        private readonly NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext _context;

        public IndexModel(NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext context)
        {
            _context = context;
        }

        public IList<Document> Document { get;set; }
        public DocumentData DocumentD { get; set; }
        public int DocumentID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            DocumentD = new DocumentData();

            DocumentD.Documents = await _context.Document
            .Include(b => b.Publisher)
            .Include(b => b.DocumentCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                DocumentID = id.Value;
                Document document = DocumentD.Documents
                .Where(i => i.ID == id.Value).Single();
                DocumentD.Categories = document.DocumentCategories.Select(s => s.Category);
            }
        }
    }

}
