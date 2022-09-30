using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Managers;

namespace ClassLibrary.Services
{
    public class ConsoleDrawer
    {
        public static void DrawAll()
        {
            Build[] builds = BuildsManager.GetInstance.Builds;
            Unit[] units = UnitsManager.GetInstance.Units;
            Console.Clear();
            Console.WriteLine("Нажмите 1 - чтобы добавить Ферму, 2 - Железный рудник, 3 - Золотой рудник, 4 - Барак, 5 - Случайную постройку");
            Console.WriteLine("Нажмите SpaceBar - чтобы начать поиск");

            Console.WriteLine($"Ресурсы \nЕда: {Manager.Food} Железо: {Manager.Iron} Золото: {Manager.Gold}\n");
            foreach (var build in builds)
            {
                if (build is Factory)
                {
                    DrawFactory(build as Factory);
                }
            }

            foreach (var unit in units)
            {
                DrawUnit(unit);
            }
        }

        public static void DrawFactory(Factory build)
        {
            Console.WriteLine(build.Name);
            Console.WriteLine($"Жизни: {build.CurrHealth}/{build.Health}");
            if (build is FactoryUnits)
            {
                Console.Write($"Очередь: {(build as FactoryUnits).Queue}/{(build as FactoryUnits).QueueCount}");
                Console.WriteLine();
            }

            Console.Write("Прогресс выполнения здания: ");
            float process = 3 * build.Progress;
            for (int i = 0; i < process; i++)
            {
                Console.Write(".");
            }

            Console.WriteLine("\n");
        }

        public static void DrawUnit(Unit unit)
        {
            Console.Write(unit.Name + " ");
        }
    }
}
