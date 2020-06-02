using BaseFramework.Core.Business;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICompanyService : IServiceBase
    {
        List<CompanyDTO> getAll();
        CompanyDTO newCompany(CompanyDTO company);
        CompanyDTO updateCompany(CompanyDTO company);
        bool deleteCompany(int companyId);
        CompanyDTO getCompany(int Id);
    }
}
