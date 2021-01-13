using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaguDenisa_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Numele categoriei")]
        [Required(ErrorMessage = "Numele categoriei nu poate fi lăsat necompletat")]
        public string CategoryName { get; set; }
        public ICollection<DocumentCategory> DocumentCategories { get; set; }
    }
}
