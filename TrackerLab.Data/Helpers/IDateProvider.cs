using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Helpers
{
    public interface IDateProvider
    {
        DateTime UtcDate { get; }
    }
}
