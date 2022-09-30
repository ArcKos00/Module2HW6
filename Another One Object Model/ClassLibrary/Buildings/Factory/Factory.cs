using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public abstract class Factory : Build, IBuilding, IProgressBar
    {
        private float _progress;
        public Factory(int cost, float buildingTime, float health)
            : base(cost, buildingTime, health)
        {
            _progress = 0;
        }

        public float Progress
        {
            get { return _progress; }
            set { _progress = value; }
        }

        public override void ProgressBar()
        {
        }
    }
}
