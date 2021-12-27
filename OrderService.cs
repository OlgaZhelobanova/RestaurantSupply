using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class OrderService
    {
        EDMmodel db;

        public OrderService()
        {
            db = new EDMmodel();
        }

        public bool MakeOrder(OrderBLL o, OrderLineBLL ol)
        {
            Order order = new Order
            {
                Status = "Новая",
                RegistrationDate = DateTime.Now,
                Priority = o.Priority,
                Supplier = o.Supplier,
                Doer = o.Doer
            };

            OrderLine orderLine = new OrderLine
            {
                Product = ol.Product,
                Quantity = ol.Quantity,
                Measure = ol.Measure,
                Order = order.Id

            };

            db.Order.Add(order);
            db.OrderLine.Add(orderLine);


            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
