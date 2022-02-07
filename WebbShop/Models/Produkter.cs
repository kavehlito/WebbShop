using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Produkter
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int? KategoriId { get; set; }
        public double? EnhetsPris { get; set; }
        public string ProduktInfo { get; set; }
        public int? LeverantörId { get; set; }
        public int? LagerAntal { get; set; }

        public virtual Kategorier Kategori { get; set; }
        public virtual Leverantör Leverantör { get; set; }
    }
}
