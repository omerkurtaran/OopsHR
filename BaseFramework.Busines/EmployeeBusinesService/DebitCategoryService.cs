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
    public class DebitCategoryService : IDebitCategoryService
    {
        private readonly IUnitofWork uow;
        public DebitCategoryService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteDebitCategory(int debitCategoryId)
        {
            try
            {
                var getDebitCategory = uow.GetRepository<DebitCategory>().Get(z => z.Id == debitCategoryId);
                uow.GetRepository<DebitCategory>().Delete(getDebitCategory);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DebitCategoryDTO> getAll()
        {
            var getDebitCategoryList = uow.GetRepository<DebitCategory>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<DebitCategoryDTO>>(getDebitCategoryList);
        }

        public DebitCategoryDTO getDebitCategory(int Id)
        {
            var getDebitCategory = uow.GetRepository<DebitCategory>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<DebitCategoryDTO>(getDebitCategory);
        }

        public DebitCategoryDTO newDebitCategory(DebitCategoryDTO debitCategory)
        {
            if (!uow.GetRepository<DebitCategory>().GetAll().Any(z => z.Id == debitCategory.Id))
            {
                var adedDebitCategory = MapperFactory.CurrentMapper.Map<DebitCategory>(debitCategory);
                adedDebitCategory = uow.GetRepository<DebitCategory>().Add(adedDebitCategory);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<DebitCategoryDTO>(adedDebitCategory);
            }
            else
            {
                return null;
            }
        }

        public DebitCategoryDTO updateDebitCategory(DebitCategoryDTO debitCategory)
        {
            var selectedDebitCategory = uow.GetRepository<DebitCategory>().Get(z => z.Id == debitCategory.Id);
            selectedDebitCategory = MapperFactory.CurrentMapper.Map(debitCategory, selectedDebitCategory);
            uow.GetRepository<DebitCategory>().Update(selectedDebitCategory);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<DebitCategoryDTO>(selectedDebitCategory);
        }
    }
}
