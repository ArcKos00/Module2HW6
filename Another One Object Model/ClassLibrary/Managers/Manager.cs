using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Manager
    {
        private static int _food;
        private static int _gold;
        private static int _iron;
        private static Manager _instance = new Manager();
        private Manager()
        {
        }

        public delegate void MyLittleTimer();
        public event MyLittleTimer MicroTimer;

        public static Manager GetInstance
        {
            get
            {
                return _instance;
            }
            set
            {
                if (_instance == null)
                {
                    _instance = new Manager();
                }
            }
        }

        public static int Iron
        {
            get { return _iron; }
            set { _iron = value; }
        }

        public static int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public static int Food
        {
            get { return _food; }
            set { Food = value; }
        }

        public void Starter()
        {
            Build build1 = new FactoryResource(Config.FarmCost, Config.FarmName, Config.FarmTimeBuilding, Config.FarmHealth, Config.FarmRes, Config.FarmCountRes, Config.FarmTimeExtract);

            while (true)
            {
                MicroTimer?.Invoke();
                Console.WriteLine("Food: " + _food);
                Console.WriteLine("Iron: " + _iron);
                Console.WriteLine("Gold: " + _gold);
            }
        }

        public static void AddToManager(int count, string name)
        {
            switch (name)
            {
                case "Iron":
                    _iron += count;
                    break;
                case "Food":
                    _food += count;
                    break;
                case "Gold":
                    _gold += count;
                    break;
            }
        }
    }
}