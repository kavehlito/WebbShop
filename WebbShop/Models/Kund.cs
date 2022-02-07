using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Kund
    {
        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int? Telefonnummer { get; set; }
        public string Adress { get; set; }
    }
}
