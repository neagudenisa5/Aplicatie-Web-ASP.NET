using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeaguDenisa_Proiect.Data;
using NeaguDenisa_Proiect.Models;

namespace NeaguDenisa_Proiect.Pages.Documents
{
    public class CreateModel : DocumentCategoriesPageModel
    {
        private readonly NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext _context;

        public CreateModel(NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var document = new Document();
            document.DocumentCategories = new List<DocumentCategory>();
            PopulateAssignedCategoryData(_context, document);
            return Page();
        }

        [BindProperty]
        public Document Document { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDocument = new Document();
            if (selectedCategories != null)
            {
                newDocument.DocumentCategories = new List<DocumentCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DocumentCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDocument.DocumentCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Document>(
            newDocument,
            "Document",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Document.Add(newDocument);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDocument);
            return Page();
        }
    }
}
