using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Technique : Unit
    {
        public Technique(string name, float time, int cost)
            : base(name, time, cost)
        {
        }
    }
}
