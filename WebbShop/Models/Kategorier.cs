using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Kategorier
    {
        public Kategorier()
        {
            Produkters = new HashSet<Produkter>();
        }

        public int Id { get; set; }
        public string Namn { get; set; }

        public virtual ICollection<Produkter> Produkters { get; set; }
    }
}
