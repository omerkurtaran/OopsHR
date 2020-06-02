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
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitofWork uow;
        public ExpenseService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteExpense(int ExpenseId)
        {
            try
            {
                var getExpense = uow.GetRepository<Expense>().Get(z => z.Id == ExpenseId);
                uow.GetRepository<Expense>().Delete(getExpense);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ExpenseDTO> getAll()
        {
            var getExpenseList = uow.GetRepository<Expense>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<ExpenseDTO>>(getExpenseList);
        }

        public ExpenseDTO getExpense(int Id)
        {
            var getExpense = uow.GetRepository<Expense>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<ExpenseDTO>(getExpense);
        }

        public ExpenseDTO newExpense(ExpenseDTO Expense)
        {
            if (!uow.GetRepository<Expense>().GetAll().Any(z => z.Id == Expense.Id))
            {
                var adedExpense = MapperFactory.CurrentMapper.Map<Expense>(Expense);
                adedExpense = uow.GetRepository<Expense>().Add(adedExpense);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ExpenseDTO>(adedExpense);
            }
            else
            {
                return null;
            }
        }

        public ExpenseDTO updateExpense(ExpenseDTO Expense)
        {
            var selectedExpense = uow.GetRepository<Expense>().Get(z => z.Id == Expense.Id);
            selectedExpense = MapperFactory.CurrentMapper.Map(Expense, selectedExpense);
            uow.GetRepository<Expense>().Update(selectedExpense);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ExpenseDTO>(selectedExpense);
        }
    }
}
