using Microsoft.Extensions.DependencyInjection;

namespace Sampler.Basic.Core
{
    public interface IDependencyConfig
    {
        void Configure(IServiceCollection serviceCollection);
    }
}
