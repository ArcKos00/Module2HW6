using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public class FactoryUnits : Factory, IUnitSpawn, IProgressBar
    {
        private int _queueCount;
        private Unit _unitToSpawn;
        private Unit[] _units;
        private Unit[] _queue;
        public FactoryUnits(int cost, string name, float buildingTime, float health, int queue, params Unit[] unitsArr)
            : base(cost, buildingTime, health)
        {
            _queueCount = queue;
            _queue = new Unit[queue];
            _units = unitsArr;
            Manager.GetInstance.MicroTimer += ProgressBar;
        }

        public override void ProgressBar()
        {
            _unitToSpawn = ChangerUnit();
            if (_unitToSpawn == null)
            {
                return;
            }

            Progress += 0.1f;
            if (Progress >= _unitToSpawn.TimeSpawn)
            {
                UnitSpawn(_unitToSpawn);
                Progress = 0;
            }
        }

        public void UnitSpawn(Unit unit)
        {
            Spawner.Spawn(unit);
            RemoveFromQueue(ref _queue);
        }

        private Unit ChangerUnit()
        {
            if (_queue[0] != null)
            {
                return _queue[0];
            }

            return null;
        }

        private void AddToQueue(ref Unit[] arr, Unit unit)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    counter++;
                }
            }

            if (counter < arr.Length)
            {
                arr[counter - 1] = unit;
            }
            else
            {
                Console.WriteLine($"{unit.Name} не добавлен в очередь, очередь занята!!!");
            }
        }

        private void RemoveFromQueue(ref Unit[] arr)
        {
            arr[0] = null;
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
        }
    }
}
