using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class OrderBLL
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        public string Priority { get; set; }

        public string Supplier { get; set; }

        public int? Doer { get; set; }

        public OrderBLL() { }

        public OrderBLL(Order o)
        {
            Id = o.Id;
            Status = o.Status;
            RegistrationDate = o.RegistrationDate;
            ClosingDate = o.ClosingDate;
            Priority = o.Priority;
            Supplier = o.Supplier;
            Doer = o.Doer;
        }
    }
}
