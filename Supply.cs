using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
   public class SupplyBLL
    {
        public int Id { get; set; }

        public string Supplier { get; set; }

        public DateTime? Date { get; set; }

        public decimal? Total { get; set; }

        public int? Doer { get; set; }

        public int? Order { get; set; }

        public SupplyBLL() { }

        public SupplyBLL(Supply s)
        {
            Id = s.Id;
            Supplier = s.Supplier;
            Date = s.Date;
            Total = s.Total;
            Doer = s.Doer;
            Order = s.Order;
        }

    }
}
