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
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IUnitofWork uow;
        public MaritalStatusService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteMaritalStatus(int maritalStatusId)
        {
            try
            {
                var getMaritalStatus = uow.GetRepository<MaritalStatus>().Get(z => z.Id == maritalStatusId);
                uow.GetRepository<MaritalStatus>().Delete(getMaritalStatus);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MaritalStatusDTO> getAll()
        {
            var getMaritalStatusList = uow.GetRepository<MaritalStatus>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<MaritalStatusDTO>>(getMaritalStatusList);
        }

        public MaritalStatusDTO getMaritalStatus(int Id)
        {
            var getMaritalStatus = uow.GetRepository<MaritalStatus>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<MaritalStatusDTO>(getMaritalStatus);
        }

        public MaritalStatusDTO newMaritalStatus(MaritalStatusDTO maritalStatus)
        {
            if (!uow.GetRepository<MaritalStatus>().GetAll().Any(z => z.Id == maritalStatus.Id))
            {
                var adedMaritalStatus = MapperFactory.CurrentMapper.Map<MaritalStatus>(maritalStatus);
                adedMaritalStatus = uow.GetRepository<MaritalStatus>().Add(adedMaritalStatus);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<MaritalStatusDTO>(adedMaritalStatus);
            }
            else
            {
                return null;
            }
        }

        public MaritalStatusDTO updateMaritalStatus(MaritalStatusDTO maritalStatus)
        {
            var selectedMaritalStatus = uow.GetRepository<MaritalStatus>().Get(z => z.Id == maritalStatus.Id);
            selectedMaritalStatus = MapperFactory.CurrentMapper.Map(maritalStatus, selectedMaritalStatus);
            uow.GetRepository<MaritalStatus>().Update(selectedMaritalStatus);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<MaritalStatusDTO>(selectedMaritalStatus);
        }
    }
}
