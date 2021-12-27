using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class ProductBLL
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Measure { get; set; }

        public DateTime ShelfLife { get; set; }

        public ProductBLL() { }

        public ProductBLL(Product p)
        {
            Id = p.Id;
            Name = p.Name;
            Quantity = p.Quantity;
            Measure = p.Measure;
            ShelfLife = p.ShelfLife;
        }
    }
}
