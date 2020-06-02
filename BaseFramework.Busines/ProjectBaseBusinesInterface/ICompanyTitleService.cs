using BaseFramework.Core.Business;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICompanyTitleService : IServiceBase
    {
        List<CompanyTitleDTO> GetAll();
        List<CompanyTitleDTO> getSelectByCompanyId(int companyId);
        CompanyTitleDTO newTitle(CompanyTitleDTO title);
        CompanyTitleDTO updateTitle(CompanyTitleDTO title);
        bool deleteTitle(int titleId);
        CompanyTitleDTO getTitle(int Id);
        CompanyTitleDTO FindwithTitle(string companyTitle);
    }
}
