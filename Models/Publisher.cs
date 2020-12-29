using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaguDenisa_Proiect.Models
{
    public class Publisher
    {
        //codul unic al editurii
        public int ID { get; set; }
        [Display(Name = "Editura")]
        public string PublisherName { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
