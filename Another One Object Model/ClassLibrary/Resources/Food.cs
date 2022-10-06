using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Food : Resource
    {
        public Food()
        {
            Name = Config.ResourceName2;
            Cost = Config.ResourceCost2;
            TimeExtract = Config.ResourceTimeExtraction2;
        }
    }
}
