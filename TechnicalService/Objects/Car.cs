using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Modules;

namespace TechnicalService.Objects
{
    public class Car
    {
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Type { get; private set; }
        public int Numb { get; private set; }
        public bool Active { get; set; }

        Dictionary<int, string> Components = new Dictionary<int, string>();

        public Car(string model, int year, string type, int numb, bool active)
        {
            Model = model;
            Year = year;
            Type = type;
            Numb = numb;
            Active = active;
        }

        public void AddComponent(int code, string name)
        {
            Components.Add(code, name);
        }
        
        public string CarComponents()
        {
            int i = 0;
            string str = "";
            foreach (var item in Components)
            {
                i++;
                str += string.Format("{0}\t{1}\t{2}\n", i,item.Key, item.Value);
            }
            return str;
        }

        public override string ToString()
        {
            //if (Active) Console.ForegroundColor = ConsoleColor.Green;
            //else Console.ForegroundColor = ConsoleColor.Red;
            return string.Format("Model: {0},\tYear: {1}\nType: {2},\tNumb: {3}", Model, Year, Type, Numb);
        }
    }
}
