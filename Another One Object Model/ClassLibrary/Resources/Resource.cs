using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class Resource
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public float TimeExtract { get; set; }
    }
}
