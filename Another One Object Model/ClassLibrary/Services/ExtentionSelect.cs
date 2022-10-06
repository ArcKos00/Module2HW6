using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    public static class ExtentionSelect
    {
        public static void GetUnits(this Unit[] units)
        {
            Console.WriteLine("Выберите тип юнитов для поиска: 1 - Солдат, 2 - Машина\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Unit[] arrU = Enumeration<Unit, Soldier>(units);
                    if (arrU.Length < 1)
                    {
                        break;
                    }

                    for (int i = 0; i < arrU.Length; i++)
                    {
                        Console.Write($"Индекс Юнита: {i} ");
                        ConsoleDrawer.DrawUnit(arrU[i] as Soldier);
                    }

                    break;
                case ConsoleKey.D2:
                    Unit[] arrR = Enumeration<Unit, Technique>(units);
                    if (arrR.Length < 1)
                    {
                        break;
                    }

                    for (int i = 0; i < arrR.Length; i++)
                    {
                        Console.Write($"Индекс Юнита: {i} ");
                        ConsoleDrawer.DrawUnit(arrR[i] as Technique);
                    }

                    Console.ReadLine();
                    break;
            }
        }

        public static void GetBuilds(this Build[] builds)
        {
            Console.WriteLine("Выберите тип зданий для поиска: 1 - Строения для cоздания юнитов, 2 - Производственные строения\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Build[] arrU = Enumeration<Build, FactoryUnits>(builds);
                    if (arrU.Length < 1)
                    {
                        break;
                    }

                    for (int i = 0; i < arrU.Length; i++)
                    {
                        Console.WriteLine($"Индекс здания: {i}");
                        ConsoleDrawer.DrawFactory(arrU[i] as Factory);
                    }

                    ChangeRemoveOrSpawn(arrU);
                    break;
                case ConsoleKey.D2:
                    Build[] arrR = Enumeration<Build, FactoryResource>(builds);
                    if (arrR.Length < 1)
                    {
                        break;
                    }

                    for (int i = 0; i < arrR.Length; i++)
                    {
                        Console.WriteLine($"Индекс здания: {i}");
                        ConsoleDrawer.DrawFactory(arrR[i] as Factory);
                    }

                    RemoveBuild(arrR);
                    break;
            }
        }

        private static void ChangeRemoveOrSpawn(Build[] arrU)
        {
            Console.WriteLine("Разрушить строение - 1, Начать обучение юнита - 2");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    RemoveBuild(arrU);
                    break;
                case ConsoleKey.D2:
                    ChangeUnitToSpawn(arrU[ChangeBuild(arrU)] as FactoryUnits);
                    break;
            }
        }

        private static void RemoveBuild(Build[] arrR)
        {
            Console.WriteLine("Удалить элемент по индексу");
            BuildsManager.GetInstance.Remove(ChangeBuild(arrR));
        }

        private static T[] Enumeration<T, I>(T[] build)
        {
            int counter = 0;
            for (int i = 0; i < build.Length; i++)
            {
                if (build[i] is I)
                {
                    counter++;
                }
            }

            T[] arr = new T[counter];
            counter = 0;
            for (int i = 0; i < build.Length; i++)
            {
                if (build[i] is I)
                {
                    arr[counter] = build[i];
                    counter++;
                }
            }

            return arr;
        }

        private static int ChangeBuild(Build[] items)
        {
            Console.WriteLine("Ввыбрать конкретную единицу нажмите Enter: ");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Введите индекс и нажмите Enter: ");
                return int.Parse(Console.ReadLine());
            }

            return 0;
        }

        private static void ChangeUnitToSpawn(FactoryUnits build)
        {
            for (int i = 0; i < build.UnitsToSpawn.Length; i++)
            {
                Console.WriteLine($"{i + 1} {build.UnitsToSpawn[i]}");
            }

            bool enable = true;
            while (enable)
            {
                try
                {
                    ChangeSpawn(build);
                    Console.WriteLine("Добавлено в очередь");
                }
                catch
                {
                    enable = false;
                }
            }
        }

        private static void ChangeSpawn(FactoryUnits build)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (Manager.Gold >= Config.SoldierCost &&
                        Manager.Food >= Config.SoldierFoodNeeded)
                    {
                        build.AddToQueue(build.UnitsToSpawn[0]);
                        Manager.Gold -= Config.SoldierCost;
                        Manager.Food -= Config.SoldierFoodNeeded;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота или еды!!!");
                        throw new Exception();
                    }

                    break;
                case ConsoleKey.D2:
                    if (Manager.Gold >= Config.CarCost &&
                        Manager.Food >= Config.CarFoodNeeded &&
                        Manager.Iron >= Config.CarIronNeed)
                    {
                        build.AddToQueue(build.UnitsToSpawn[1]);
                        Manager.Gold -= Config.CarCost;
                        Manager.Food -= Config.CarFoodNeeded;
                        Manager.Iron -= Config.CarIronNeed;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота, железа или еды!!!");
                        throw new Exception();
                    }

                    break;
            }
        }
    }
}
