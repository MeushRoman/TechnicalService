using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalService.Modules
{
    public class CreateProject
    {
        public List<string> Projects { get; set; }

        public void CreateNewProject(string name)
        {
            Projects.Add(name);
        }

        public override string ToString()
        {
            int i = 0;
            string str = "";
            foreach (string item in Projects)
            {
                i++;
                str += string.Format("{0}. {1}",i,item);
            }
            return str;
        }
    }
}
