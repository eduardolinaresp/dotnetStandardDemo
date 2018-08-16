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

                String mensaje = "Contiene los siguientes items:";

                Console.WriteLine("La OrdenId: {0} con Fecha: {1}", Orden.OrderId.ToString(), Orden.Fecha.ToString());
                Console.WriteLine(mensaje);

                foreach (var item in Orden.OrdersDetails)
                {
                    Console.WriteLine(item.ItemName.PadLeft(mensaje.Length + item.ItemName.Length, '.'));
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
