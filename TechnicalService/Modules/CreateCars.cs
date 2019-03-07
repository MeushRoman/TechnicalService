using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService.Modules
{
    public class CreateCars
    {
        public List<Car> Cars = new List<Car>();    

        public List<Project> Projects = new List<Project>();

        public bool CreateCar(string model, int year, string type, int numb, bool active)
        {
            if (Cars.Count > 0)
                if (Cars.Where(w => w.Numb == numb).ToList()[0] != null)
                    return false;            
            
            Cars.Add(new Car(model, year, type, numb, active));
            return true;
        }    

        public Car SearchCar(int numb)
        {            
            return Cars.Where(w => w.Numb == numb).ToList()[0];
        }

        public List<Car> SearchCar(string model)
        {
            return Cars.Where(w => w.Model == model).ToList();
        }

        public override string ToString()
        {
            string str = "";
            foreach (Car item in Cars)
            {
                str += string.Format("{0}\n-----------------\n", item);
            }
            return str;
        }


    }
}
