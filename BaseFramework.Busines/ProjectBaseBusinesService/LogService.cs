using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{
    public class LogService : ILogService
    {
        private readonly IUnitofWork uow;
        public LogService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteLog(int logId)
        {
            try
            {
                var getLog = uow.GetRepository<Log>().Get(z => z.Id == logId);
                uow.GetRepository<Log>().Delete(getLog);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<LogDTO> getAll()
        {
            var getLogList = uow.GetRepository<Log>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<LogDTO>>(getLogList);
        }

        public LogDTO getLog(int Id)
        {
            var getLog = uow.GetRepository<Log>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<LogDTO>(getLog);
        }

        public LogDTO newLog(LogDTO log)
        {
            if (!uow.GetRepository<Log>().GetAll().Any(z => z.Id == log.Id))
            {
                var adedLog = MapperFactory.CurrentMapper.Map<Log>(log);
                adedLog = uow.GetRepository<Log>().Add(adedLog);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<LogDTO>(adedLog);
            }
            else
            {
                return null;
            }
        }

        public LogDTO updateLog(LogDTO log)
        {
            var selectedLog = uow.GetRepository<Log>().Get(z => z.Id == log.Id);
            selectedLog = MapperFactory.CurrentMapper.Map(log, selectedLog);
            uow.GetRepository<Log>().Update(selectedLog);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<LogDTO>(selectedLog);
        }



    }
}