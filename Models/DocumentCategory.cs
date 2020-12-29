using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeaguDenisa_Proiect.Models
{
    public class DocumentCategory
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public Document Document { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
