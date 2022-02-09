using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Kundvagn
    {
        public int Id { get; set; }
        public int? Antal { get; set; }
        public int? ProduktId { get; set; }
    }
}
