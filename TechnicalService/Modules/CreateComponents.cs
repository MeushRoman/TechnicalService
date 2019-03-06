using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Modules
{
    class CreateComponents
    {
        public Dictionary<int, string> Components = new Dictionary<int, string>();      

        public void AddNewComponent(int code, string name)
        {
            try
            {
                Components.Add(code, name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in Components)
            {
                str += string.Format("{0}\t{1}\n",item.Key,item.Value);
            }
            return str;
        }
    }
}
