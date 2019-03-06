using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Modules;

namespace TechnicalService
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCars c = new CreateCars();
            //Console.WriteLine(c.CreateCar("model", 2015, "traktor", 4, true));
            //Console.WriteLine(c.CreateCar("model", 2015, "traktor", 4, true));

            Console.WriteLine(c.CreateCar("model", 2015, "traktor", 4, true));
            Console.WriteLine(c.CreateCar("model", 2015, "traktor", 4, true));
            Console.WriteLine(c.CreateCar("model", 2015, "traktor", 4, true));

            Console.WriteLine(c.SearchCar(4));
           
        }
    }
}
