using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class OrderDop
    {
        public class OrderData
        {
            public int Id { get; set; }

            public string Status { get; set; }

            public DateTime? RegistrationDate { get; set; }

            public DateTime? ClosingDate { get; set; }

            public string Priority { get; set; }

            public string Supplier { get; set; }

            public string Doer { get; set; }
        }

        public static List<OrderData> Orderdop ()
        {
            EDMmodel db = new EDMmodel();
            var o = db.Order
                .Join(db.Doer, order => order.Doer, doer => doer.Id, (order, doer) => new { order, doer })
                .Select(var => new OrderData()
                {
                    Id = var.order.Id,
                    Status = var.order.Status,
                    RegistrationDate = var.order.RegistrationDate,
                    ClosingDate = var.order.ClosingDate,
                    Priority = var.order.Priority,
                    Supplier = var.order.Supplier,
                    Doer = var.doer.Name
                })
                .ToList();
            return o;
        }
    }
}
