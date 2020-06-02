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
    public class OvertimeService : IOvertimeService
    {
        private readonly IUnitofWork uow;
        public OvertimeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteOvertime(int Overtime)
        {
            try
            {
                var getOvertime = uow.GetRepository<Overtime>().Get(z => z.Id == Overtime);
                uow.GetRepository<Overtime>().Delete(getOvertime);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OvertimeDTO> getAll()
        {
            var getOvertimeList = uow.GetRepository<Overtime>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<OvertimeDTO>>(getOvertimeList);
        }

        public OvertimeDTO getOvertime(int Id)
        {
            var getOvertime = uow.GetRepository<Overtime>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<OvertimeDTO>(getOvertime);
        }

        public OvertimeDTO newOvertime(OvertimeDTO Overtime)
        {
            if (!uow.GetRepository<Overtime>().GetAll().Any(z => z.Id == Overtime.Id))
            {
                var adedOvertime = MapperFactory.CurrentMapper.Map<Overtime>(Overtime);
                adedOvertime = uow.GetRepository<Overtime>().Add(adedOvertime);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<OvertimeDTO>(adedOvertime);
            }
            else
            {
                return null;
            }
        }

        public OvertimeDTO updateOvertime(OvertimeDTO Overtime)
        {
            var selectedOvertime = uow.GetRepository<Overtime>().Get(z => z.Id == Overtime.Id);
            selectedOvertime = MapperFactory.CurrentMapper.Map(Overtime, selectedOvertime);
            uow.GetRepository<Overtime>().Update(selectedOvertime);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<OvertimeDTO>(selectedOvertime);
        }

    }
}
