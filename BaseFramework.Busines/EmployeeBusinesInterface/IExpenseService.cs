using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IExpenseService : IServiceBase
    {
        List<ExpenseDTO> getAll();
        ExpenseDTO getExpense(int Id);
        ExpenseDTO newExpense(ExpenseDTO Expense);
        ExpenseDTO updateExpense(ExpenseDTO Expense);
        bool deleteExpense(int ExpenseId);

    }
}
