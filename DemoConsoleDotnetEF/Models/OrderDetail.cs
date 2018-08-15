using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleDotnetEF.Models
{
    public class OrderDetail
    {

        public int OrderDetailsId { get; set; }
        public string ItemName { get; set; }
        public int OrderId { get; set; }
        public Order Orden { get; set; }

    }
}
