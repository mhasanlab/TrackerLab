using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Helpers.HttpClientHelpers
{
    public interface IKeyValueBuilder
    {
        IKeyValueBuilder WithParam(string key, string value);
        IKeyValueBuilder WithParam<T>(string key, T value);
        string Build();
    }
}
