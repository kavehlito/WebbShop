using System;
using System.Collections.Generic;

#nullable disable

namespace WebbShop.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderdetaljers = new HashSet<Orderdetaljer>();
        }

        public int Id { get; set; }
        public int? KundId { get; set; }
        public DateTime? Orderdatum { get; set; }
        public string LeveransAdress { get; set; }
        public int? BetalsättsId { get; set; }
        public int? FraktId { get; set; }
        public double? TotalPris { get; set; }

        public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; }
    }
}
