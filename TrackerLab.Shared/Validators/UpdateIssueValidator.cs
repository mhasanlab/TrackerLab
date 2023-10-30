using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Requests.Issues;

namespace TrackerLab.Shared.Validators
{
    public class UpdateIssueValidator : AbstractValidator<UpdateIssueRequest>
    {
        public UpdateIssueValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .IsInEnum();

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.TypeId)
                .NotEmpty();
        }
    }
}
