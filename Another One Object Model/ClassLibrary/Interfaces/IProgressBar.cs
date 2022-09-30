using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IProgressBar
    {
        public float Progress
        { get; set; }

        public void ProgressBar();
    }
}
