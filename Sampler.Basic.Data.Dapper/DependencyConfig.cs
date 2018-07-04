using Microsoft.Extensions.DependencyInjection;
using Sampler.Basic.Core;

namespace Sampler.Basic.Data.Dapper
{
    public class DependencyConfig : IDependencyConfig
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConnectionManager, SqlConnectionManager>();
        }
    }
}
