using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleDotnetEF.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Fecha { get; set; }
        public List<OrderDetail> OrdersDetails { get; set; }

    }
}
