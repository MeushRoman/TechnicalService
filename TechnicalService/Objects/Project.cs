using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Modules;

namespace TechnicalService.Objects
{
    public class Project
    {
        public CreateCars Cars = new CreateCars();
        
        public string Name { get; }

        public Project(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string str = Name;
            int i = 0;
            str += string.Format("\n{0}\n {1}\n", i, Cars);
            str += "\n------------------------------------------\n";
            return str;
        }


    }
}
