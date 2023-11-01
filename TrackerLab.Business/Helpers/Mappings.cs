using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;
using TrackerLab.Shared.Responses;

namespace TrackerLab.Business.Helpers
{
    public class Mappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Issue, IssueResponse>()
               .Map(dest => dest.ProjectTitle, src => src.Project.Title);

            config.Default.MapToConstructor(true);
        }
    }
}
