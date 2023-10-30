using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Requests.Auth
{
    public class RegisterRequest
    {
        private string? _email;

        public string? Email { get => _email; set => _email = value.Trim(); }
        public string? Password { get; set; }
    }
}
