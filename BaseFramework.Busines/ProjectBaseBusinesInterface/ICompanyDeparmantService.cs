using BaseFramework.Core.Business;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICompanyDeparmantService : IServiceBase
    {
        List<CompanyDepartmentDTO> getAll();
        CompanyDepartmentDTO newDepartmant(CompanyDepartmentDTO companyDeparment);
        CompanyDepartmentDTO updateDepartmant(CompanyDepartmentDTO companyDeparment);
        bool deleteDepartmant(int DepartmantId);
        CompanyDepartmentDTO getDepartmant(int Id);
    }
}
