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
    public class RequestForVisaService : IRequestForVisaService
    {
        private readonly IUnitofWork uow;
        public RequestForVisaService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteRequestForVisa(int RequestForVisaId)
        {
            try
            {
                var getRequestForVisa = uow.GetRepository<RequestForVisa>().Get(z => z.Id == RequestForVisaId);
                uow.GetRepository<RequestForVisa>().Delete(getRequestForVisa);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<RequestForVisaDTO> getAll()
        {
            var getRequestForVisaList = uow.GetRepository<RequestForVisa>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<RequestForVisaDTO>>(getRequestForVisaList);
        }

        public RequestForVisaDTO getRequestForVisa(int Id)
        {
            var getRequestForVisa = uow.GetRepository<RequestForVisa>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<RequestForVisaDTO>(getRequestForVisa);
        }

        public RequestForVisaDTO newRequestForVisa(RequestForVisaDTO RequestForVisa)
        {
            if (!uow.GetRepository<RequestForVisa>().GetAll().Any(z => z.Id == RequestForVisa.Id))
            {
                var adedRequestForVisa = MapperFactory.CurrentMapper.Map<RequestForVisa>(RequestForVisa);
                adedRequestForVisa = uow.GetRepository<RequestForVisa>().Add(adedRequestForVisa);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RequestForVisaDTO>(adedRequestForVisa);
            }
            else
            {
                return null;
            }
        }

        public RequestForVisaDTO updateRequestForVisa(RequestForVisaDTO RequestForVisa)
        {
            var selectedRequestForVisa = uow.GetRepository<RequestForVisa>().Get(z => z.Id == RequestForVisa.Id);
            selectedRequestForVisa = MapperFactory.CurrentMapper.Map(RequestForVisa, selectedRequestForVisa);
            uow.GetRepository<RequestForVisa>().Update(selectedRequestForVisa);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RequestForVisaDTO>(selectedRequestForVisa);
        }
    }
}
