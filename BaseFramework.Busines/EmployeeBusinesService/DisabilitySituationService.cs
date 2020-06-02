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
    public class DisabilitySituationService : IDisabilitySituationService
    {
        private readonly IUnitofWork uow;
        public DisabilitySituationService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteDisabilitySituation(int disabilitySituationId)
        {
            try
            {
                var getDisabilitySituation = uow.GetRepository<DisabilitySituation>().Get(z => z.Id == disabilitySituationId);
                uow.GetRepository<DisabilitySituation>().Delete(getDisabilitySituation);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DisabilitySituationDTO> getAll()
        {
            var getDisabilitySituationList = uow.GetRepository<DisabilitySituation>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<DisabilitySituationDTO>>(getDisabilitySituationList);
        }

        public DisabilitySituationDTO getDisabilitySituation(int Id)
        {
            var getDisabilitySituation = uow.GetRepository<DisabilitySituation>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<DisabilitySituationDTO>(getDisabilitySituation);
        }

        public DisabilitySituationDTO newDisabilitySituation(DisabilitySituationDTO disabilitySituation)
        {
            if (!uow.GetRepository<DisabilitySituation>().GetAll().Any(z => z.Id == disabilitySituation.Id))
            {
                var adedDisabilitySituation = MapperFactory.CurrentMapper.Map<DisabilitySituation>(disabilitySituation);
                adedDisabilitySituation = uow.GetRepository<DisabilitySituation>().Add(adedDisabilitySituation);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DisabilitySituationDTO>(adedDisabilitySituation);
            }
            else
            {
                return null;
            }
        }

        public DisabilitySituationDTO updateDisabilitySituation(DisabilitySituationDTO disabilitySituation)
        {
            var selectedDisabilitySituation = uow.GetRepository<DisabilitySituation>().Get(z => z.Id == disabilitySituation.Id);
            selectedDisabilitySituation = MapperFactory.CurrentMapper.Map(disabilitySituation, selectedDisabilitySituation);
            uow.GetRepository<DisabilitySituation>().Update(selectedDisabilitySituation);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DisabilitySituationDTO>(selectedDisabilitySituation);
        }
    }
}
