using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Requests.Auth
{
    public class RefreshTokenRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string? RefreshToken { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? AccessToken { get; set; }
    }
}
