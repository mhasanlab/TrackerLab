using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Options
{
    public class JwtOptions
    {
        public string TokenKey { get; init; }
        public string ValidIssuer { get; init; }
        public string ValidAudience { get; init; }
    }
}
