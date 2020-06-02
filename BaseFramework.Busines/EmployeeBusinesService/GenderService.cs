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
    public class GenderService : IGenderService
    {
        private readonly IUnitofWork uow;
        public GenderService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteGender(int genderId)
        {
            try
            {
                var getGender = uow.GetRepository<Gender>().Get(z => z.Id == genderId);
                uow.GetRepository<Gender>().Delete(getGender);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GenderDTO> getAll()
        {
            var getGenderList = uow.GetRepository<Gender>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<GenderDTO>>(getGenderList);
        }

        public GenderDTO getGender(int Id)
        {
            var getGender = uow.GetRepository<Gender>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<GenderDTO>(getGender);
        }

        public GenderDTO newGender(GenderDTO gender)
        {
            if (!uow.GetRepository<Gender>().GetAll().Any(z => z.Id == gender.Id))
            {
                var adedGender = MapperFactory.CurrentMapper.Map<Gender>(gender);
                adedGender = uow.GetRepository<Gender>().Add(adedGender);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<GenderDTO>(adedGender);
            }
            else
            {
                return null;
            }
        }

        public GenderDTO updateGender(GenderDTO gender)
        {
            var selectedGender = uow.GetRepository<Gender>().Get(z => z.Id == gender.Id);
            selectedGender = MapperFactory.CurrentMapper.Map(gender, selectedGender);
            uow.GetRepository<Gender>().Update(selectedGender);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<GenderDTO>(selectedGender);
        }
    }
}
