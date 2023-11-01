using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Commands.Auth
{
    public class ConfirmEmailCommand : IRequest
    {
        public ConfirmEmailCommand(string userId, string confirmationToken)
        {
            UserId = userId;
            ConfirmationToken = confirmationToken;
        }

        public string UserId { get; }
        public string ConfirmationToken { get; }
    }
}
