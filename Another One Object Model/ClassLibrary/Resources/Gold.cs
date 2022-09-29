using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Gold : Resource
    {
        public Gold()
        {
            Name = Config.ResourceName3;
            Cost = Config.ResourceCost3;
            TimeExtract = Config.ResourceTimeExtraction3;
        }
    }
}
