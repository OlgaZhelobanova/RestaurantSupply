using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class SupplyLineBLL
    {
        public int Id { get; set; }

        public int? Product { get; set; }

        public int? Quantity { get; set; }

        public string Measure { get; set; }

        public decimal? Cost { get; set; }

        public DateTime? ShelfLife { get; set; }

        public int Supply { get; set; }

        public SupplyLineBLL() { }

        public SupplyLineBLL(SupplyLine sl)
        {
            Id = sl.Id;
            Product = sl.Product;
            Quantity = sl.Quantity;
            Measure = sl.Measure;
            Cost = sl.Cost;
            ShelfLife = sl.ShelfLife;
            Supply = sl.Supply;
        }
    }
}
