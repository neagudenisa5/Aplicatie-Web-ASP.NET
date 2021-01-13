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
        //codul unic al editurii, cheia primara ID va fi cheie straina pentru entitatea Document
        public int ID { get; set; }
        [Display(Name = "Editura")]
        [Required(ErrorMessage = "Numele editurii nu poate fi lăsat necompletat")]
        public string PublisherName { get; set; }
        //Cand o entitate Document are o entitate relationata Publisher, fiecare va avea o referinta catre cealalta in navigation property
        public ICollection<Document> Documents { get; set; }
    }
}
