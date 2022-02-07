using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Frakt
    {
        public int Id { get; set; }
        public string FraktAlternativ { get; set; }
        public double? FraktPris { get; set; }
    }
}
