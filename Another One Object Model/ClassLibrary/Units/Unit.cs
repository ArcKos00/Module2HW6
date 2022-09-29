using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Unit
    {
        private string _name;
        private float _time;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float TimeSpawn
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
