using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Requests.Sprints;

namespace TrackerLab.Shared.Validators
{
    public class AddSprintValidator : AbstractValidator<AddSprintRequest>
    {
        public AddSprintValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate).WithMessage("Sprint cannot end before start date");
        }
    }
}
