using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Objects
{
    public class Project
    {
        public List<Car> Cars = new List<Car>();
        public string Name { get; }

        public Project(string name)
        {
            Name = name;
        }

        public void AddCarInProject(Car car)
        {
            Cars.Add(car);
        }

        public override string ToString()
        {
            string str = Name;
            int i = 0;
            foreach (Car item in Cars)
            {
                i++;
                str +=string.Format("\n{0}\n {1}\n",i, item);
            }
            str += "\n------------------------------------------\n";
            return str;
        }


    }
}
