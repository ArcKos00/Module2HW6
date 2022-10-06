using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Services;

namespace ClassLibrary.Managers
{
    public class UnitsManager
    {
        private static UnitsManager _manager = new UnitsManager();
        private Unit[] _units;

        private UnitsManager()
        {
            _units = new Unit[0];
        }

        public static UnitsManager GetInstance
        {
            get
            {
                return _manager;
            }
            set
            {
                if (_manager == null)
                {
                    _manager = new UnitsManager();
                }
            }
        }

        public Unit[] Units
        {
            get { return _units; }
        }

        public void AddResize(Unit unit)
        {
            Service.AddResize<Unit>(ref _units);
            _units[_units.Length - 1] = unit;
        }

        public void RemoveResize(int index)
        {
            Service.RemoveResize<Unit>(ref _units, index);
        }
    }
}
