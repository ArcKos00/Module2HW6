using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Managers;

namespace ClassLibrary.Services
{
    public class Spawner
    {
        public static void Spawn(Unit unit)
        {
            if (unit is Soldier)
            {
                SpawnSoldier();
            }
            else if (unit is Technique)
            {
                SpawnCar();
            }
        }

        private static void SpawnSoldier()
        {
            UnitsManager.GetInstance.AddResize(new Soldier(
                                Config.SoldierName,
                                Config.SoldierSpawnTime,
                                Config.SoldierCost));
        }

        private static void SpawnCar()
        {
            UnitsManager.GetInstance.AddResize(new Technique(
                                Config.CarName,
                                Config.CarSpawnTime,
                                Config.CarCost));
        }
    }
}
