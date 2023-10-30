using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Responses
{
    public class ApiError
    {
        public ApiError(string message, string stackTrace = null)
        {
            Message = message;
            StackTrace = stackTrace;
        }

        public string StackTrace { get; }
        public string Message { get; }
    }
}
