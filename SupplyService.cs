using DALnew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLnew
{
   public class SupplyService
    {
        public class ResultProduct
        {
            public string DishName { get; set; }
        }

        //public static string SupplyProduct(int id)
        //{
            //EDMmodel db = new EDMmodel();

            //var r = from sl in db.SupplyLine
            //join s in db.Supply on sl.Supply equals s.Id

            //   where(s.Order == id)
            //  select new 
            //   {
            //       DishName = sl.Product1.Name
            //   }.ToString();
            //return r;
        //}
    }
}
