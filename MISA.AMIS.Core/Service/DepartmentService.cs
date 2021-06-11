using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSH.Core.Service
{
    public class DepartmentService: BaseService<Department>, IDepartmentService
    {
        public DepartmentService(IBaseRepository<Department> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
