using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Modules;
using TechnicalService.Console;
namespace TechnicalService
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.MainMenu();

            //CreateProject cp = new CreateProject();

            //cp.CreateNewProject("p1");
            //cp.CreateNewProject("p2");
            //cp.CreateNewProject("p3");

            
            //cp.projects[1].Cars.CreateCar("Model", 2015, "dd", 33, true);
            //System.Console.WriteLine(cp);
            //System.Console.WriteLine("{0},{1}",cp.projects[1],cp.projects[1].Cars);

        }
    }
}
