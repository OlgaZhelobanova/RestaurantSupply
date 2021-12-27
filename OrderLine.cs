using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class OrderLineBLL
    {
        public int Id { get; set; }

        public int? Product { get; set; }

        public int? Quantity { get; set; }

        public string Measure { get; set; }

        public int Order { get; set; }

        public OrderLineBLL() { }

        public OrderLineBLL(OrderLine o)
        {
            Id = o.Id;
            Product = o.Product;
            Quantity = o.Quantity;
            Measure = o.Measure;
            Order = o.Order;
        }

    }
}
