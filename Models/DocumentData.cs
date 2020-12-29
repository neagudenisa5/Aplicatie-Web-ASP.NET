using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeaguDenisa_Proiect.Models
{
    public class DocumentData
    {
        public IEnumerable<Document> Documents { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DocumentCategory> DocumentCategories { get; set; }
    }
}
