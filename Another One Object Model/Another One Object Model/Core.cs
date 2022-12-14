using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Managers;
using ClassLibrary.Services;

namespace Another_One_Object_Model
{
    internal class Core
    {
        private static Core _core = new Core();
        private BuildsManager _builds;
        private Manager _logic;
        private UnitsManager _units;

        private Core()
        {
        }

        public static Core GetCore
        {
            get
            {
                return _core;
            }
            set
            {
                if (_core == null)
                {
                    _core = new Core();
                }
            }
        }

        public Manager GetLogic
        {
            get { return _logic; }
            set { _logic = value; }
        }

        public void Starter()
        {
            ConsoleDrawer.DrawAll();
            float counter2 = 0;
            while (true)
            {
                _logic = Manager.GetInstance;
                _logic.Tick();
                if (counter2 >= 5)
                {
                    ConsoleDrawer.DrawAll();
                    counter2 = 0;
                    Thread.Sleep(500);
                }

                if (Console.KeyAvailable)
                {
                    ChangeAction();
                }

                counter2 += 1f;
            }
        }

        private void ChangeAction()
        {
            _builds = BuildsManager.GetInstance;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    if (Manager.Gold >= Config.FarmCost)
                    {
                        _builds.Add(false, "Farm");
                        Manager.Gold -= Config.FarmCost;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно Золота!!");
                    }

                    break;
                case ConsoleKey.D2:
                    if (Manager.Gold >= Config.IronMineCost)
                    {
                        _builds.Add(false, "Iron");
                        Manager.Gold -= Config.IronMineCost;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно Золота!!");
                    }

                    break;
                case ConsoleKey.D3:
                    if (Manager.Gold >= Config.GoldMineCost)
                    {
                        _builds.Add(false, "Gold");
                        Manager.Gold -= Config.GoldMineCost;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно Золота!!");
                    }

                    break;
                case ConsoleKey.D4:
                    if (Manager.Gold >= Config.BarrackCost)
                    {
                        _builds.Add(false, "Barracks");
                        Manager.Gold -= Config.BarrackCost;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно Золота!!");
                    }

                    break;
                case ConsoleKey.Spacebar:
                    ChangeExtension();
                    break;
                default:
                    break;
            }
        }

        private void ChangeExtension()
        {
            _builds = BuildsManager.GetInstance;
            Thread.Sleep(100);
            Console.WriteLine("Выберите направление поиска: 1 - Строения, 2 - Юниты");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    _builds.Builds.GetBuilds();
                    break;
                case ConsoleKey.D2:
                    _units.Units.GetUnits();
                    break;
            }
        }
    }
}
