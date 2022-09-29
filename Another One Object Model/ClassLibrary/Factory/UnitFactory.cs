using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary
{
    public class UnitFactory : IUnitSpawn
    {
        private UnitFactory _factory = new UnitFactory();

        private UnitFactory()
        {
        }

        public void UnitSpawn()
        {
            throw new NotImplementedException();
        }
    }
}
