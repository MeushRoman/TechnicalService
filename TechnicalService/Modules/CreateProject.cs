using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService.Modules
{
    public class CreateProject
    {

        public List<Project> projects = new List<Project>();

        public bool CreateNewProject(string name)
        {
            if (projects.Where(w => w.Name.Equals(name)).ToList().Count > 0)
                return false;

            projects.Add(new Project(name));
            return true;
        }

        public override string ToString()
        {
            int i = 0;
            string str = "";
            foreach (Project item in projects)
            {
                i++;
                str += string.Format("{0}. {1}\n", i, item.Name);
            }
            return str;
        }
    }
}
