using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class SupplyDop
    {
        public class SupplyData
        {
            public int Id { get; set; }

            public string Supplier { get; set; }

            public DateTime? Date { get; set; }

            public decimal? Total { get; set; }

            public string Doer { get; set; }

            public int? Order { get; set; }
        }

        public static List<SupplyData> Supplydop()
        {
            EDMmodel db = new EDMmodel();
            var s = db.Supply
                .Join(db.Doer, supply => supply.Doer, doer => doer.Id, (supply, doer) => new { supply, doer })
                .Select(var => new SupplyData()
                {
                    Id = var.supply.Id,
                    Supplier = var.supply.Supplier,
                    Date = var.supply.Date,
                    Total = var.supply.Total,
                    Order = var.supply.Order,
                    Doer = var.doer.Name
                })
                .ToList();
            return s;
        }
    }
}
