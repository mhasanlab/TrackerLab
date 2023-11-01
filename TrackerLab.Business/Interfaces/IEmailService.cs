using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string subject, string body, string to);
        Task SendEmailConfirmationAsync(string confirmationToken, string userId, string to);
    }
}
