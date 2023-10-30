using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Requests.Projects;

namespace TrackerLab.Shared.Validators
{
    public class AddProjectValidator : AbstractValidator<AddProjectRequest>
    {
        public AddProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
        }
    }
}
