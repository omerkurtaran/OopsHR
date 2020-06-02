
using BaseFramework.Entity;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Entity.ProjectBaseEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Dal
{
    public class BaseFrameworkEntities : DbContext
    {
        public BaseFrameworkEntities() : base("name=BaseFrameworkDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        #region employeeEntity
        public DbSet<AccessType> AccessTypes { get; set; }
        public DbSet<Advance> Advances { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }
        public DbSet<BankInformation> BankInformations { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<DebitCategory> DebitCategories { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<DisabilitySituation> DisabilitySituations { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EducationStatus> EducationStatuses { get; set; }
        public DbSet<EducationsType> EducationsTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<EmployeeOtherInfo> EmployeeOtherInfos { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<PermitType> PermitTypes { get; set; }
        public DbSet<Permit> Permits { get; set; }
        public DbSet<RequestForVisa> RequestForVisas { get; set; }
        public DbSet<SystemEducation> SystemEducations { get; set; }
        public DbSet<VisaType> VisaTypes { get; set; }

        #endregion

        #region projectBaseEntity
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageEvent> PageEvents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }


        #endregion

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyBranch> CompanyBranches { get; set; }
        public DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public DbSet<CompanyTitle> CompanyTitles { get; set; }

    }

}
