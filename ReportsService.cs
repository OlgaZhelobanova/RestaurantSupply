using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
    public class ReportsService
    {
        public class Result
        {
            public string DishName { get; set; }
            public int DishQuantity { get; set; }
            public DateTime ReceiptDate { get; set; }
        }

        public static List<Result> StatisticsForMonth(int month) 
        {
            EDMmodel db = new EDMmodel();

            var r = db.ReceiptLine
              .Join(db.Receipt, recl => recl.Receipt, rec => rec.Id, (recl, rec) => new { recl, rec })
               .Where(var => var.rec.Date.Month == month)
               .Select(var => new Result()
               {
                   DishName = var.recl.Dish1.Name,
                   DishQuantity = var.recl.Quantity,
                   ReceiptDate = var.rec.Date
               })
               .ToList();
            return r;
        }
    }
}
