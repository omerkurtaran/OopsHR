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
    public class EmployeeOtherInfoService : IEmployeeOtherInfoService
    {
        private readonly IUnitofWork uow;
        public EmployeeOtherInfoService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEmployeeOtherInfo(int employeeOtherInfoId)
        {
            try
            {
                var getEmployeeOtherInfo = uow.GetRepository<EmployeeOtherInfo>().Get(z => z.Id == employeeOtherInfoId);
                uow.GetRepository<EmployeeOtherInfo>().Delete(getEmployeeOtherInfo);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeOtherInfoDTO> getAll()
        {
            var getEmployeeOtherInfoList = uow.GetRepository<EmployeeOtherInfo>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EmployeeOtherInfoDTO>>(getEmployeeOtherInfoList);
        }

        public EmployeeOtherInfoDTO getEmployeeOtherInfo(int Id)
        {
            var getEmployeeOtherInfo = uow.GetRepository<EmployeeOtherInfo>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EmployeeOtherInfoDTO>(getEmployeeOtherInfo);
        }

        public EmployeeOtherInfoDTO newEmployeeOtherInfo(EmployeeOtherInfoDTO employeeOtherInfo)
        {
            if (!uow.GetRepository<EmployeeOtherInfo>().GetAll().Any(z => z.Id == employeeOtherInfo.Id))
            {
                var adedEmployeeOtherInfo = MapperFactory.CurrentMapper.Map<EmployeeOtherInfo>(employeeOtherInfo);
                adedEmployeeOtherInfo = uow.GetRepository<EmployeeOtherInfo>().Add(adedEmployeeOtherInfo);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EmployeeOtherInfoDTO>(adedEmployeeOtherInfo);
            }
            else
            {
                return null;
            }
        }

        public EmployeeOtherInfoDTO updateEmployeeOtherInfo(EmployeeOtherInfoDTO employeeOtherInfo)
        {
            var selectedEmployeeOtherInfo = uow.GetRepository<EmployeeOtherInfo>().Get(z => z.Id == employeeOtherInfo.Id);
            selectedEmployeeOtherInfo = MapperFactory.CurrentMapper.Map(employeeOtherInfo, selectedEmployeeOtherInfo);
            uow.GetRepository<EmployeeOtherInfo>().Update(selectedEmployeeOtherInfo);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EmployeeOtherInfoDTO>(selectedEmployeeOtherInfo);
        }
    }
}