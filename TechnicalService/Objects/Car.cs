using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Objects
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Numb { get; set; }
        public bool Active { get; set; }
       

        public Car(string model, int year, string type, int numb, bool active)
        {
            Model = model;
            Year = Year;
            Type = type;
            Numb = numb;
            Active = active;
        }

        public override string ToString()
        {
            //if (Active) Console.ForegroundColor = ConsoleColor.Red;
            //else Console.ForegroundColor = ConsoleColor.Green;
            return string.Format("Model: {0},\t Year: {1}\nType: {2},\tNumb: {3}", Model, Year, Type, Numb);
        }
    }
}
