using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public class FactoryResource : Factory, IBuilding, IResourceSpawn, IProgressBar
    {
        private Resource _resource;
        private int _countRes;
        private float _time;

        public FactoryResource(int cost, string name, float buildingTime, float health, Resource res, int valueToMine, float timeToMine)
            : base(cost, buildingTime, health)
        {
            _time = timeToMine;
            _countRes = valueToMine;
            _resource = res;
            Name = res.Name + name;
            Manager.GetInstance.MicroTimer += ProgressBar;
        }

        public override void ProgressBar()
        {
            if (!IsEnable)
            {
                return;
            }

            Progress += 0.1f;
            if (Progress >= _time)
            {
                ResourceSpawn();
                Progress = 0;

                Thread.Sleep(100);
            }
        }

        public void ResourceSpawn()
        {
            Manager.AddToManager(_countRes, _resource.Name);
        }
    }
}
