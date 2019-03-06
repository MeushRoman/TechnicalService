using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Objects
{
    public class CarBroken
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
        public string RecForRepare { get; set; }
        public Users User { get; set; }

        public CarBroken(DateTime createDate, Car car, string description, string recForRepair, Users user)
        {
            CreateDate = createDate;
            Car.Numb = car.Numb;
            Description = description;
            RecForRepare = recForRepair;
            User.Id = user.Id;
        }
    }
}
