using Sampler.Basic.Data.Models;

namespace Sampler.Basic.Data
{
    public interface IDepartmentRepository
    {
        Department Get(int id);

        void Save(Department department);
    }
}
