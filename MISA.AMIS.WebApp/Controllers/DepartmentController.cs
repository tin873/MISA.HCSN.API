using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSN.API.Controllers
{
    public class DepartmentController : MisaBaseController<Department>
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
