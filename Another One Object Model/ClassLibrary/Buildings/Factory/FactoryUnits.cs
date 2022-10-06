using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Services;

namespace ClassLibrary
{
    public class FactoryUnits : Factory, IBuilding, IUnitSpawn, IProgressBar
    {
        private int _currQueue;
        private int _queueCount;
        private Unit _unitToSpawn;
        private Unit[] _units;
        private Unit[] _queue;
        public FactoryUnits(int cost, string name, float buildingTime, float health, int queue, params Unit[] unitsArr)
            : base(cost, buildingTime, health)
        {
            Name = name;
            _queueCount = queue;
            _currQueue = 0;
            _queue = new Unit[queue];
            _units = unitsArr;
            Manager.GetInstance.MicroTimer += ProgressBar;
        }

        public int QueueCount
        {
            get { return _queueCount; }
        }

        public int Queue
        {
            get { return _currQueue; }
        }

        public Unit[] UnitsToSpawn
        {
            get { return _units; }
        }

        public override void ProgressBar()
        {
            _unitToSpawn = ChangerUnit();
            if (_unitToSpawn == null || !IsEnable)
            {
                Progress = 0;
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

        public void AddToQueue(Unit unit)
        {
            int counter = 0;
            for (int i = 0; i < _queueCount; i++)
            {
                if (_queue[i] != null)
                {
                    counter++;
                }
            }

            if (counter < _queue.Length)
            {
                _queue[counter] = unit;
                _currQueue++;
            }
            else
            {
                Console.WriteLine($"{unit.Name} не добавлен в очередь, очередь занята!!!");
                throw new Exception();
            }
        }

        private Unit ChangerUnit()
        {
            if (_queue[0] != null)
            {
                return _queue[0];
            }

            return null;
        }

        private void RemoveFromQueue(ref Unit[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }

            _currQueue--;
        }
    }
}
