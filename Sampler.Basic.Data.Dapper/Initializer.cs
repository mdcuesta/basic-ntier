using DapperExtensions.Mapper;
using Sampler.Basic.Core;

namespace Sampler.Basic.Data.Dapper
{
    public class Initializer : IInitializer
    {
        public void Init()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(PluralizedAutoClassMapper<>);
        }
    }
}
