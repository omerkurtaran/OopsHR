using BaseFramework.Core.Business;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICompanyBranchService : IServiceBase
    {
        List<CompanyBranchDTO> getAll();
        List<CompanyBranchDTO> getSelectByCompanyId(int companyId);
        CompanyBranchDTO newCompanyBranch(CompanyBranchDTO CompanyBranch);
        CompanyBranchDTO updateCompanyBranch(CompanyBranchDTO CompanyBranch);
        bool deleteCompanyBranch(int CompanyBranchId);
        CompanyBranchDTO getCompanyBranch(int Id);
    }
}
