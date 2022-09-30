using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Config
    {
        // Iron
        public static string ResourceName1 => "Iron";
        public static int ResourceCost1 => 10;
        public static float ResourceTimeExtraction1 => 3f;

        // Food
        public static string ResourceName2 => "Food";
        public static int ResourceCost2 => 3;
        public static float ResourceTimeExtraction2 => 2f;

        // Gold
        public static string ResourceName3 => "Gold";
        public static int ResourceCost3 => 20;
        public static float ResourceTimeExtraction3 => 3f;

        // FoodFarm
        public static string FarmName => "Farm";
        public static int FarmCost => 150;
        public static float FarmTimeBuilding => 7f;
        public static float FarmHealth => 100;
        public static Resource FarmRes => new Food();
        public static int FarmCountRes => 5;
        public static float FarmTimeExtract => 5f;

        // IronMine
        public static string IronMineName => "Mine";
        public static int IronMineCost => 170;
        public static float IronMineTimeBuilding => 10f;
        public static float IronMineHealth => 100;
        public static Resource IronMineRes => new Iron();
        public static int IronMineCountRes => 5;
        public static float IronMineTimeExtract => 9f;

        // GoldMine
        public static string GoldMineName => "Mine";
        public static int GoldMineCost => 170;
        public static float GoldMineTimeBuilding => 10f;
        public static float GoldMineHealth => 100;
        public static Resource GoldMineRes => new Gold();
        public static int GoldMineCountRes => 15;
        public static float GoldMineTimeExtract => 9f;

        // Barracks
        public static string BarrackName => "Barracks";
        public static int BarrackCost => 200;
        public static float BarrackBuildingTime => 10f;
        public static float BarrackHealth => 100;
        public static int BarrackQueue => 5;
        public static Unit[] BarrackUnits => new Unit[]
        {
            new Soldier(
                SoldierName,
                SoldierSpawnTime,
                SoldierCost),
            new Technique(
                CarName,
                CarSpawnTime,
                CarCost)
        };

        // Soldier
        public static string SoldierName => "Soldier";
        public static float SoldierSpawnTime => 5f;
        public static int SoldierCost => 50;
        public static int SoldierFoodNeeded => 10;

        // Car
        public static string CarName => "Jeep";
        public static float CarSpawnTime => 7f;
        public static int CarCost => 100;
        public static int CarFoodNeeded => 15;
        public static int CarIronNeed => 20;
    }
}
