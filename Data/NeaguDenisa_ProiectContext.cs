using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeaguDenisa_Proiect.Models;

namespace NeaguDenisa_Proiect.Data
{
    public class NeaguDenisa_ProiectContext : DbContext
    {
        public NeaguDenisa_ProiectContext (DbContextOptions<NeaguDenisa_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<NeaguDenisa_Proiect.Models.Document> Document { get; set; }

        public DbSet<NeaguDenisa_Proiect.Models.Publisher> Publisher { get; set; }

        public DbSet<NeaguDenisa_Proiect.Models.Category> Category { get; set; }
    }
}
