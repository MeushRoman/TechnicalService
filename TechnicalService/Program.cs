using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceUser ser = new ServiceUser();
            
            ser.FindByProject("Com");
            
            

        }

        
    }
}
