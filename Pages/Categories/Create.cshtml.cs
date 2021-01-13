using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeaguDenisa_Proiect.Data;
using NeaguDenisa_Proiect.Models;

namespace NeaguDenisa_Proiect.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext _context;

        public CreateModel(NeaguDenisa_Proiect.Data.NeaguDenisa_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            //daca a fost apasat butonul de salvare, se va crea o categorie noua si ne va redirectiona catre lista cu toate categoriile
            return RedirectToPage("./Index");
        }
    }
}
