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
    public class DebitService : IDebitService
    {
        private readonly IUnitofWork uow;

        public DebitService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteDebit(int Id)
        {
            try
            {
                var getDebit = uow.GetRepository<Debit>().Get(z => z.Id == Id);
                uow.GetRepository<Debit>().Delete(getDebit);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<DebitDTO> getAll()
        {
            var getDebitList = uow.GetRepository<Debit>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<DebitDTO>>(getDebitList);
        }

        public DebitDTO getDebit(int Id)
        {
            var getDebit = uow.GetRepository<Debit>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<DebitDTO>(getDebit);
        }

        public DebitDTO newDebit(DebitDTO Debit)
        {
            if (!uow.GetRepository<Debit>().GetAll().Any(z => z.Id == Debit.Id))
            {
                var adedDebit = MapperFactory.CurrentMapper.Map<Debit>(Debit);
                adedDebit = uow.GetRepository<Debit>().Add(adedDebit);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DebitDTO>(adedDebit);
            }
            else
            {
                return null;
            }
        }

        public DebitDTO updateDebit(DebitDTO Debit)
        {
            var selectedDebit = uow.GetRepository<Debit>().Get(z => z.Id == Debit.Id);
            selectedDebit = MapperFactory.CurrentMapper.Map(Debit, selectedDebit);
            uow.GetRepository<Debit>().Update(selectedDebit);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DebitDTO>(selectedDebit);
        }
    }
}
