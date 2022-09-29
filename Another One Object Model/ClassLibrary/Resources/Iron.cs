using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Iron : Resource
    {
        public Iron()
        {
            Name = Config.ResourceName1;
            Cost = Config.ResourceCost1;
            TimeExtract = Config.ResourceTimeExtraction1;
        }
    }
}
