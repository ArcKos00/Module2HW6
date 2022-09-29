using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace ClassLibrary
{
    public static class BuildSpawner
    {
        public static Build SpawnFarm()
        {
            return new FactoryResource(
                Config.FarmCost,
                Config.FarmName,
                Config.FarmTimeBuilding,
                Config.FarmHealth,
                Config.FarmRes,
                Config.FarmCountRes,
                Config.FarmTimeExtract);
        }

        public static Build SpawnIronMine()
        {
            return new FactoryResource(
                Config.IronMineCost,
                Config.IronMineName,
                Config.IronMineTimeBuilding,
                Config.IronMineHealth,
                Config.IronMineRes,
                Config.IronMineCountRes,
                Config.IronMineTimeExtract);
        }

        public static Build SpawnGoldMine()
        {
            return new FactoryResource(
                Config.GoldMineCost,
                Config.GoldMineName,
                Config.GoldMineTimeBuilding,
                Config.GoldMineHealth,
                Config.GoldMineRes,
                Config.GoldMineCountRes,
                Config.GoldMineTimeExtract);
        }

        public static Build SpawnBarracks()
        {
            return new FactoryUnits(
                Config.BarrackCost,
                Config.BarrackName,
                Config.BarrackBuildingTime,
                Config.BarrackHealth,
                Config.BarrackQueue,
                Config.BarrackUnits);
        }
    }
}
