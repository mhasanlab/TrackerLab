using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Requests.IssueTypes;

namespace TrackerLab.Shared.Validators
{
    public class UpdateIssueTypeValidator : AbstractValidator<UpdateIssueTypeRequest>
    {
        public UpdateIssueTypeValidator()
        {
            RuleFor(x => x.Color)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
