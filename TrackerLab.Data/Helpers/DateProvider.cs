using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Helpers
{
    public class DateProvider : IDateProvider
    {
        public DateTime UtcDate => DateTime.UtcNow;
    }
}
