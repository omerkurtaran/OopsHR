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
    public class DemandService : IDemandService
    {
        private readonly IUnitofWork uow;
        public DemandService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteDemand(int demandId)
        {
            try
            {
                var getDemand = uow.GetRepository<Demand>().Get(z => z.Id == demandId);
                uow.GetRepository<Demand>().Delete(getDemand);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DemandDTO> getAll()
        {
            var getDemandList = uow.GetRepository<Demand>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<DemandDTO>>(getDemandList);
        }

        public DemandDTO getDemand(int Id)
        {
            var getDemand = uow.GetRepository<Demand>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<DemandDTO>(getDemand);
        }

        public DemandDTO newDemand(DemandDTO demand)
        {
            if (!uow.GetRepository<Demand>().GetAll().Any(z => z.Id == demand.Id))
            {
                var adedDemand = MapperFactory.CurrentMapper.Map<Demand>(demand);
                adedDemand = uow.GetRepository<Demand>().Add(adedDemand);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DemandDTO>(adedDemand);
            }
            else
            {
                return null;
            }
        }

        public DemandDTO updateDemand(DemandDTO demand)
        {
            var selectedDemand = uow.GetRepository<Demand>().Get(z => z.Id == demand.Id);
            selectedDemand = MapperFactory.CurrentMapper.Map(demand, selectedDemand);
            uow.GetRepository<Demand>().Update(selectedDemand);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DemandDTO>(selectedDemand);
        }
    }
}
