using System.Data;

namespace Sampler.Basic.Data.Dapper
{
    public interface IConnectionManager
    {
        IDbConnection Create();
    }
}
