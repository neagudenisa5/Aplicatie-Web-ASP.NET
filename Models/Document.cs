using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaguDenisa_Proiect.Models
{
    public class Document
    {
        //Proprietatile unei reviste
        public int ID { get; set; } //campul unic de identificare a inregistrarii (cheia primara)
        [Display(Name = "Numele revistei")]
        //minim 2 caractere, maxim 50, completat obligatoriu
        [Required(ErrorMessage = "Numele revistei nu poate fi lăsat necompletat")]
        [StringLength(50, MinimumLength = 2,ErrorMessage="Numele revistei trebuie sa aiba minim 2 si maxim 50 de caractere")]
        public string Title { get; set; } //titlul revistei
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required,StringLength(50, MinimumLength = 3)]
        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere
        [Display(Name = "Autorul")]
        public string Author { get; set; } //autorul revistei
        [Display(Name = "Pretul (Lei)")]
        [Column(TypeName = "decimal(6, 2)")]
        //pret maxim 50 de lei
        [Range(1, 50, ErrorMessage = "Vă rugăm să introduceți o valoare între 1 și 50 de lei")]
        public int Price { get; set; } //pretul revistei
        [Display(Name = "Data publicarii")]
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; } //data publicarii revistei
        public int PublisherID { get; set; } //cheia externa a editurii
        [Display(Name = "Editura")]
        public Publisher Publisher { get; set; } //proprietatea de navighare a editurii
        [Display(Name = "Categoria")]
        public ICollection<DocumentCategory> DocumentCategories { get; set; }
        
    }
}
