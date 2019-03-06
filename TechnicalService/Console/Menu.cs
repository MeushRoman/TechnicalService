using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnicalService.Objects;

namespace TechnicalService.Console
{
    public class Menu
    {

        public void WelcomeMenu()
        {
            System.Console.WriteLine("Добро пожаловать!");
            Thread.Sleep(1500);
            System.Console.Clear();
            System.Console.WriteLine("Вас приветствует приложение, реализующие систему контроля технического обслуживания машин");
            Thread.Sleep(1500);
            System.Console.Clear();
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
                    System.Console.Clear();
                    ManageMenu();
                }
                else if (ch == 2)
                {
                    System.Console.Clear();
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
                System.Console.Clear();
                MainMenu();
            }



        }
        public void CreationMenu()
        {
            System.Console.WriteLine("1. Добавить машину\n2. Создать компонент машины\n3. Создать проект\n4. Создать пользователя\n5. Создать останову\n6. Назад\n");
            System.Console.WriteLine("\n Ваш выбор: ");
            int choice = int.Parse(System.Console.ReadLine());
            while (!(choice >= 7))
            {
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        {
                            System.Console.Clear();
                            UserMenu u = new UserMenu();
                            u.Create();
                            System.Console.WriteLine("Еще одного? д/н");
                            string ch = System.Console.ReadLine();
                            System.Console.Clear();
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
                        System.Console.Clear();
                        MainMenu();

                        break;
                    default:
                        break;
                }
            }
            if (choice >= 7)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
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
                        System.Console.Clear();

                        MainMenu();
                        break;
                    default:
                        break;
                }
            }

            if (choice >= 7)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
                ManageMenu();
            }
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        System.Console.Clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 4)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
                CarMenu();
            }
        }

        public void ComponentMenu()
        {
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
                        System.Console.Clear();

                        ManageMenu();
                        break;

                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
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
                        System.Console.Clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
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
                        System.Console.Clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
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
                        System.Console.Clear();

                        ManageMenu();
                        break;
                    default:
                        break;
                }
            }
            if (choice >= 3)
            {
                System.Console.WriteLine("Неверный выбор");
                System.Console.Clear();
                CarBrokeMenu();
            }

        }
    }
}
