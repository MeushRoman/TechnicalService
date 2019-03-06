using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Objects
{
    public class CarBroken
    {
        public DateTime CreateDate { get; set; }
        public Car car { get; set; }
        public string Description { get; set; }
        public string RecForRepare { get; set; }
        // public User user { get; set; }
    }
}
