using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace TechnicalService.Objects
{
    public delegate void PrintMessage(string str);
    public delegate void ShowError(Exception ex);
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Access { get; set; }

        public string Project { get; set; }

        public Users(string login, string password, string access, string project)
        {

            this.Login = login;
            this.Password = password;
            this.Access = access;
            this.Project = project;
        }
        
    }
    
}
