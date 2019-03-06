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

        public string CreateCar(string model, int year, string type, int numb, bool active)
        {
            if (Cars.Where(w => w.Numb == numb).ToList()[0] == null)
            {
                Cars.Add(new Car(model, year, type, numb, active));
                return "Успешно создан";
            }
            else            
                return "Гаражный номер занят";            
        }

        public Car SearchCar(int numb)
        {            
            return Cars.Where(w => w.Numb == numb).ToList()[0];
        }

        public List<Car> SearchCar(string model)
        {
            return Cars.Where(w => w.Model == model).ToList();
        }
    }
}
