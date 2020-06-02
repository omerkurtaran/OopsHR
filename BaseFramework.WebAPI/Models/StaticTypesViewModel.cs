using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseFramework.WebAPI.Models
{
    public class StaticTypesViewModel
    {
        public List<BloodGroupDTO> bloodGroupList { get; set; }
        public List<AccessTypeDTO> accessTypeList { get; set; }
    }
}