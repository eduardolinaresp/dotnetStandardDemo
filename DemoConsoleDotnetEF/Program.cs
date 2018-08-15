using DemoConsoleDotnetEF.Models;
using DemoConsoleDotnetEF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleDotnetEF
{
    class Program
    {
        static void Main(string[] args)
        {
  

            try
            {
                OrderService _OrderService = new OrderService();

                Order Orden = _OrderService.Read(1);

                Console.WriteLine("La OrdenId: {0} con Fecha: {1}", Orden.OrderId.ToString(), Orden.Fecha.ToString());

                foreach (var item in Orden.OrdersDetails)
                {
                    Console.WriteLine("Contiene los siguientes items: {0}", item.ItemName);
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            Console.ReadKey();



        }
    }
}
