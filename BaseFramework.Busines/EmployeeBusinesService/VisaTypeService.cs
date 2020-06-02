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
    public class VisaTypeService : IVisaTypeService
    {
        private readonly IUnitofWork uow;
        public VisaTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteVisaType(int VisaTypeId)
        {
            try
            {
                var getVisaType = uow.GetRepository<VisaType>().Get(z => z.Id == VisaTypeId);
                uow.GetRepository<VisaType>().Delete(getVisaType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<VisaTypeDTO> getAll()
        {
            var getVisaTypeList = uow.GetRepository<VisaType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<VisaTypeDTO>>(getVisaTypeList);
        }

        public VisaTypeDTO getVisaType(int Id)
        {
            var getVisaType = uow.GetRepository<VisaType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<VisaTypeDTO>(getVisaType);
        }

        public VisaTypeDTO newVisaType(VisaTypeDTO VisaType)
        {
            if (!uow.GetRepository<VisaType>().GetAll().Any(z => z.Id == VisaType.Id))
            {
                var adedVisaType = MapperFactory.CurrentMapper.Map<VisaType>(VisaType);
                adedVisaType = uow.GetRepository<VisaType>().Add(adedVisaType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<VisaTypeDTO>(adedVisaType);
            }
            else
            {
                return null;
            }
        }

        public VisaTypeDTO updateVisaType(VisaTypeDTO VisaType)
        {
            var selectedVisaType = uow.GetRepository<VisaType>().Get(z => z.Id == VisaType.Id);
            selectedVisaType = MapperFactory.CurrentMapper.Map(VisaType, selectedVisaType);
            uow.GetRepository<VisaType>().Update(selectedVisaType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<VisaTypeDTO>(selectedVisaType);
        }
    }
}
