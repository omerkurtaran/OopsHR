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
    public class AdvanceService : IAdvanceService
    {
        private readonly IUnitofWork uow;
        public AdvanceService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteAdvance(int advanceId)
        {
            try
            {
                var getAdvance = uow.GetRepository<Advance>().Get(z => z.Id == advanceId);
                uow.GetRepository<Advance>().Delete(getAdvance);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<AdvanceDTO> getAll()
        {
            var getAdvanceList = uow.GetRepository<Advance>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<AdvanceDTO>>(getAdvanceList);
        }

        public AdvanceDTO getAdvance(int Id)
        {
            var getAdvance = uow.GetRepository<Advance>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<AdvanceDTO>(getAdvance);
        }

        public AdvanceDTO newAdvance(AdvanceDTO advance)
        {
            if (!uow.GetRepository<Advance>().GetAll().Any(z => z.Id == advance.Id))
            {
                var adedAdvance = MapperFactory.CurrentMapper.Map<Advance>(advance);
                adedAdvance = uow.GetRepository<Advance>().Add(adedAdvance);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<AdvanceDTO>(adedAdvance);
            }
            else
            {
                return null;
            }
        }

        public AdvanceDTO updateAdvance(AdvanceDTO advance)
        {
            var selectedAdvance = uow.GetRepository<Advance>().Get(z => z.Id == advance.Id);
            selectedAdvance = MapperFactory.CurrentMapper.Map(advance, selectedAdvance);
            uow.GetRepository<Advance>().Update(selectedAdvance);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<AdvanceDTO>(selectedAdvance);
        }
    }
}
