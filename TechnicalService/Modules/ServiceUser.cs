using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace TechnicalService.Objects
{
    public delegate void SendNotification(Users sw);
    public class ServiceUser
    {
        PrintMessage printMessage;
        ShowError showError;
        SendNotification sendNotification;

        public void RegisterNotification(SendNotification sendNotification)
        {
            this.sendNotification = sendNotification;
        }

        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }

        public string DBName { get; set; }

        public void CreateUser(string login, string password, string access, string project)
        {
            Users u = new Users(login, password, access, project);
            ServiceUser serU = new ServiceUser();
            serU.DBName = @"C:\Users\Жанара\Source\Repos\TechnicalService\TechnicalService\bin\Debug\User.db";
            serU.RegisterError(PrintMessage);
            serU.RegisterMessage(PrintMessage);
            serU.AddUsers(u);
        }

        public void AddUsers(Users user)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var users = db.GetCollection<Users>("Users");
                    users.Insert(user);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись добавлена успешно");

                if (sendNotification != null)
                    sendNotification.Invoke(user);
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public List<Users> FindByProject(string project)
        {
            List<Users> listUsers = null;
            try
            {
                if (string.IsNullOrEmpty(@"User.db"))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(@"User.db"))
                {
                    var users = db.GetCollection<Users>("User");
                    listUsers = users.Find(x => x.Project.Equals(project)).ToList();
                }
                return listUsers;
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
                return listUsers;
            }
            
        }


        public static void PrintMessage(string str)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(str);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void PrintMessage(Exception ex)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(ex.Message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void SendNotification(Users u)
        {
            System.Console.WriteLine("Уведомление об установке отпарвлено");
        }
    }
}

