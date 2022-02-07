using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Orderdetaljer
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProduktId { get; set; }
        public double? Enhetspris { get; set; }
        public int? Antal { get; set; }
        public int? LeverantörId { get; set; }

        public virtual Order Order { get; set; }
    }
}
