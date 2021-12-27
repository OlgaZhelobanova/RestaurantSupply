using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class CRUD
    {
        private EDMmodel db;

        public CRUD()
        {
            db = new EDMmodel();
        }

        public List<ProductBLL> GetAllProducts()
        {
            return db.Product.ToList().Select(i => new ProductBLL(i)).ToList();
        }


        public List<OrderBLL> GetAllOrders()
        {
            return db.Order.ToList().Select(i => new OrderBLL(i)).ToList();
        }

        public List<DoerBLL> GetAllDoers()
        {
            return db.Doer.ToList().Select(i => new DoerBLL(i)).ToList();
        }

        public List<SupplyBLL> GetAllSupplies()
        {
            return db.Supply.ToList().Select(i => new SupplyBLL(i)).ToList();
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public void CreateOrder(OrderBLL o)
        {
            db.Order.Add(new Order() { Status=o.Status, RegistrationDate=o.RegistrationDate, Priority=o.Priority, Supplier=o.Supplier, Doer=o.Doer });
            Save();
        }

        public void CreateOrderLine(OrderLineBLL o)
        {
            db.OrderLine.Add(new OrderLine() { Product = o.Product, Quantity = o.Quantity, Measure = o.Measure, Order = o.Order});
            Save();
        }

        public void UpdateStatus(OrderBLL ob)
        {
            Order o = db.Order.Find(ob.Id);
            o.Status = ob.Status;
            o.ClosingDate = ob.ClosingDate;
            Save();
        }

        //public void DeleteDrug(int id)
        //{
        //    Лекарство d = db.Лекарство.Find(id);
        //    if (d != null)
        //    {
        //        db.Лекарство.Remove(d);
        //        Save();
        //    }
        //}
    }
}
