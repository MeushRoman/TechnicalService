using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService.Modules
{
    public delegate void SendNotification(CarBroken cb);
    public class CarBrokenService
    {
        List<CarBroken> carB = new List<CarBroken>();
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

        public void CreateCarBroken(DateTime createDate, Car car, string description, string recForRepair, Users user)
        {
            CarBroken CB = new CarBroken(createDate, car, description, recForRepair, user);
            CarBrokenService CBU = new CarBrokenService();
            CBU.DBName = @"C:\Users\Жанара\Source\Repos\TechnicalService\TechnicalService\bin\Debug\CarBroken.db";
            CBU.RegisterError(PrintMessage);
            CBU.RegisterMessage(PrintMessage);
            CBU.AddCarBroken(CB);
        }

        public void AddCarBroken(CarBroken carB)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var carBroken = db.GetCollection<CarBroken>("CarBroken");
                    carBroken.Insert(carB);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись добавлена успешно");

                if (sendNotification != null)
                    sendNotification.Invoke(carB);
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public List<CarBroken> ShowCarBroken()
        {
            carB = null;
            try
            {
                if (string.IsNullOrEmpty(@"CarBroken.db"))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(@"CarBroken.db"))
                {
                    var carsB = db.GetCollection<CarBroken>("CarBroken");
                    carB = carsB.FindAll().ToList();
                }
                return carB;
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
                return carB;
            }
        }

        //public List<Car> CreateService(bool active)
        //{
        //    List<Car> car = new List<Car>();
        //    if (car.CompareTo(active))
        //    {

        //    }
        //}
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

        public static void SendNotification(CarBroken u)
        {
            System.Console.WriteLine("Уведомление об установке отпарвлено");
        }
    }
}
