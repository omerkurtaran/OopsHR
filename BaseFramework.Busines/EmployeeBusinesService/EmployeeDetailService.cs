using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesService
{
    public class EmployeeDetailService : IEmployeeDetailService
    {
        private readonly IUnitofWork uow;
        public EmployeeDetailService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEmployeeDetail(int employeeDetailId)
        {
            try
            {
                var getEmployeeDetail = uow.GetRepository<EmployeeDetail>().Get(z => z.Id == employeeDetailId);
                uow.GetRepository<EmployeeDetail>().Delete(getEmployeeDetail);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeDetailDTO> getAll()
        {
            var getEmployeeDetailList = uow.GetRepository<EmployeeDetail>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EmployeeDetailDTO>>(getEmployeeDetailList);
        }

        public EmployeeDetailDTO getEmployeeDetail(int Id)
        {
            var getEmployeeDetail = uow.GetRepository<EmployeeDetail>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EmployeeDetailDTO>(getEmployeeDetail);
        }

        public EmployeeDetailDTO newEmployeeDetail(EmployeeDetailDTO employeeDetail)
        {
            if (!uow.GetRepository<EmployeeDetail>().GetAll().Any(z => z.Id == 1))
            {
                var adedEmployeeDetail = MapperFactory.CurrentMapper.Map<EmployeeDetail>(employeeDetail);
                adedEmployeeDetail = uow.GetRepository<EmployeeDetail>().Add(adedEmployeeDetail);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EmployeeDetailDTO>(adedEmployeeDetail);
            }
            else
            {
                return null;
            }
        }

        public EmployeeDetailDTO updateEmployeeDetail(EmployeeDetailDTO employeeDetail)
        {
            var selectedEmployeeDetail = uow.GetRepository<EmployeeDetail>().Get(z => z.Id == employeeDetail.Id);
            selectedEmployeeDetail = MapperFactory.CurrentMapper.Map(employeeDetail, selectedEmployeeDetail);
            uow.GetRepository<EmployeeDetail>().Update(selectedEmployeeDetail);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EmployeeDetailDTO>(selectedEmployeeDetail);
        }
    }
}
