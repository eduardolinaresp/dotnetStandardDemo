using DemoConsoleDotnetEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DemoConsoleDotnetEF.Services
{
    public class OrderService
    {
        private DemoConsoleDotnetEFContext db = new DemoConsoleDotnetEFContext();
        private Order o_order = null;

        public Order Read(int p_order)
        {

            try
            {
                o_order = db.Ordenes.Include(s => s.OrdersDetails)
                                    .Where(c => c.OrderId == p_order)
                                    .FirstOrDefault<Order>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return o_order; 
        }

    }
}
