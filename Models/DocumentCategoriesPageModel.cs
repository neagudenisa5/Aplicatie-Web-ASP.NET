using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeaguDenisa_Proiect.Data;


namespace NeaguDenisa_Proiect.Models
{
    public class DocumentCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(NeaguDenisa_ProiectContext context,Document book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
            book.DocumentCategories.Select(c => c.DocumentID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(NeaguDenisa_ProiectContext context,
        string[] selectedCategories, Document bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.DocumentCategories = new List<DocumentCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.DocumentCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.DocumentCategories.Add(
                        new DocumentCategory
                        {
                            DocumentID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        DocumentCategory courseToRemove
                        = bookToUpdate
                        .DocumentCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
