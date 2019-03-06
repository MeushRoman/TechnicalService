using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService.Console
{
    public class UserMenu
    {
        public void Create()
        {
            System.Console.WriteLine("Введите логин: ");
            string login = System.Console.ReadLine();

            System.Console.WriteLine("Введите пароль: ");
            string password = System.Console.ReadLine();

            System.Console.WriteLine("Введите доступ: ");
            string access = System.Console.ReadLine();

            System.Console.WriteLine("Введите проект: ");
            string project = System.Console.ReadLine();

            ServiceUser su = new ServiceUser();
            su.CreateUser(login, password, access, project);
        }
        public void PrintByProject()
        {
            System.Console.WriteLine("Введите название проекта: ");
            string project = System.Console.ReadLine();
            ServiceUser us = new ServiceUser();
            us.FindByProject(project);

           

            
        }


    }
}
