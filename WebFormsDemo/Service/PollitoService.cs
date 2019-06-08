using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsDemo.Model;

namespace WebFormsDemo.Service
{
    public class PollitoService
    {

        public PollitoService()
        {

        }


        public Pollito ObtenerPollito()
        {
            Pollito pollo = new Pollito();

            pollo.PollitoId = 1;
            pollo.Nombre = "1";

                       
            return pollo;

        }

        //public IEnumerable<Pollito> ObtenerPollitos()
        public List<Pollito> ObtenerPollitos()
        {
            List<Pollito> polloList = new List<Pollito>();
            int cantidad = 3;

            for (int i = 0; i < cantidad; i++)
            {

                Pollito pollo = new Pollito();

                i = i + 1;
                
                //pollo.PollitoId =++ i;

                pollo.PollitoId =i;

                pollo.Nombre = string.Format("Hola soy el pollo_{0}",
                                                (i.ToString()
                                                )
                                                );

                polloList.Add(pollo);


            }



            return polloList;


        }


    }
}