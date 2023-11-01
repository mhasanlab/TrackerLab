using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetJwtTokenAsync(IdentityUser user);
        string GetRefreshToken();
        Task SendEmailConfirmationAsync(IdentityUser user);
        void ValidateToken(string accessToken);
    }
}
