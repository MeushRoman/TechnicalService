using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnicalService.Modules;
using TechnicalService.Objects;

namespace TechnicalService.Console
{
    public class Menu
    {
        public CreateProject cp = new CreateProject();
        public object CreateCar { get; private set; }

        public void WelcomeMenu()
        {
            System.Console.WriteLine("Добро пожаловать!");
            Thread.Sleep(1500);
            clear();
            System.Console.WriteLine("Вас приветствует приложение, реализующие систему контроля технического обслуживания машин");
            Thread.Sleep(1500);
            clear();
        }
        public void MainMenu()
        {
            System.Console.WriteLine("1. Управление\n2. Создание\n3. Выход");
            System.Console.WriteLine("\n Ваш выбор: ");
            int ch = int.Parse(System.Console.ReadLine());
            while (!(ch >= 4))
            {
                if (ch == 1)
                {
                    clear();
                    ManageMenu();
                }
                else if (ch == 2)
                {
                    clear();
                    CreationMenu();
                }
                else if (ch == 3)
                {
                    System.Console.WriteLine("До свидания!");
                    Thread.Sleep(1500);
                    System.Environment.Exit(1);
                }
            }
            if (ch >= 4)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                MainMenu();
            }
        }

        public void cout(string str)
        {
            System.Console.Write(str);
        }

        public void CreateProj()
        {
            clear();
            cout("Введите название проекта: ");

            string name = System.Console.ReadLine();
            if (cp.CreateNewProject(name))                  
                cout("Успешно создан!\n");       
            else
                cout("Проект с таким именем уже существует\n");

            Thread.Sleep(1000);
        }

        public void AddCar()
        {
            clear();
            int projectId;
            string model;
            int year = 0;
            string type;
            int numb = 0;

            cout("Введите номер проекта:\n");
            projectId = int.Parse(System.Console.ReadLine());
            cout("свойства машины:\n");
            cout("Модель: ");
            model = System.Console.ReadLine();
            cout("Год: ");
            year = int.Parse(System.Console.ReadLine());
            cout("Тип: ");
            type = System.Console.ReadLine();
            cout("Гаражный номер: ");
            numb = int.Parse(System.Console.ReadLine());

            if (cp.projects[projectId-1].Cars.CreateCar(model, year, type, numb, true))
                cout("Машина создана и добавлена в проект!");
            else cout("Гаражный номер занят!");
            Thread.Sleep(1000);
        }

        public void CreateComponent()
        {
            clear();
            int numb;
            int code = 0;
            string name = "";
            cout("Введите гаражный номер машины: ");
            numb = int.Parse(System.Console.ReadLine());

            foreach (Project pr in cp.projects)
            {
                foreach (Car car in pr.Cars.Cars)
                {
                    if (car.Numb != numb) cout("номер не найден!\n");
                    else
                    {
                        cout("Код компонента: ");
                        code = int.Parse(System.Console.ReadLine());
                        cout("Название Компонента");
                        name = System.Console.ReadLine();

                        car.AddComponent(code, name);
                        cout("Компонент добавлен!\n");
                        break;
                    }
                }
            }
            Thread.Sleep(1000);
        }

        public void CreationMenu()
        {
            clear();
            System.Console.WriteLine("1. Создать проект. \n2. Добавить машину\n3. Создать компонент машины\n4. Создать пользователя\n5. Создать останову\n6. Назад\n");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 7))
            {
                switch (choice)
                {
                    case 1:
                        {
                            CreateProj();
                            CreationMenu();
                        }
                        break;
                    case 2:
                        {
                            AddCar();
                            CreationMenu();
                        }
                        break;
                    case 3:
                        {
                            CreateComponent();
                            CreationMenu();
                        }
                        break;
                    case 4:
                        {
                            clear();
                            UserMenu u = new UserMenu();
                            u.Create();
                            System.Console.WriteLine("Еще одного? д/н");
                            string ch = System.Console.ReadLine();
                            clear();
                            if (ch == "д")
                            {
                                u.Create();
                            }
                            else if (ch == "н")
                            {
                                CreationMenu();
                            }
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        clear();
                        MainMenu();

                        break;
                    default:
                        break;
                }
            }
            if (choice >= 7)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                CreationMenu();
            }
        }

        public void ManageMenu()
        {
            System.Console.WriteLine("1. Машины\n2. Компоненты\n3. Проекты\n4. Пользователи\n5. Останова\n6. Назад\n");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 7))
            {
                switch (choice)
                {
                    case 1:
                        CarMenu();
                        break;
                    case 2:
                        ComponentMenu();
                        break;
                    case 3:
                        ProjectMenu();
                        break;
                    case 4:
                        UserMenu();
                        break;
                    case 5:
                        CarBrokeMenu();
                        break;
                    case 6:
                        clear();

                        MainMenu();
                        break;
                    default:
                        break;
                }
            }

            if (choice >= 7)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                ManageMenu();
            }
        }

        public void PrintCars()
        {
            foreach (Project pr in cp.projects)
            {
                cout(pr.Name+"\n------------------------------\n");
                foreach (Car car in pr.Cars.Cars)
                {                   
                    System.Console.WriteLine(car);
                }

            }
            cout("\n------------------------------\n");
            System.Console.ReadKey();
            CarMenu();

        }

        public void CarMenu()
        {
            System.Console.WriteLine("1. Отображение всего парка машина по проектам\n2. Поиск машины по его гаражному номеру, модели\n3. Установить статус Активна/Неактивная\n4. Назад");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 4))
            {
                switch (choice)
                {
                    case 1:
                        PrintCars();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 4)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                CarMenu();
            }
        }

        public void ComponentMenu()
        {
            clear();
            System.Console.WriteLine("1. Отобразить все компоненты на проекте\n2. Назад");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 3))
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        clear();

                        ManageMenu();
                        break;

                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                ComponentMenu();
            }

        }

        public void ProjectMenu()
        {
            System.Console.WriteLine("1. Отобразить весь список проектов\n2. Назад");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 3))
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                ProjectMenu();
            }
        }

        public void UserMenu()
        {
            System.Console.WriteLine("1. Отобразить весь список пользователей по проектам\n2. Назад");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 3))
            {
                switch (choice)
                {
                    case 1:
                        {
                            UserMenu um = new UserMenu();
                            um.PrintByProject();
                        }
                        break;
                    case 2:
                        clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                UserMenu();
            }

        }

        public void CarBrokeMenu()
        {
            System.Console.WriteLine("1. Отобразить весь список остановов\n2. Назад");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 3))
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                clear();
                CarBrokeMenu();
            }


        }
        public void clear()
        {
            System.Console.Clear();
        }
    }
}
