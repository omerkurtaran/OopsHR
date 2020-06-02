using BaseFramework.Entity.ProjectBaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class EmployeeOtherInfo
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public string AdressInfo { get; set; }
        public string AdressFull { get; set; }
        public Nullable<int> HomePhone { get; set; }
        public string ContactNameforEmergency { get; set; }
        public string RelationshipforEmergencyContact { get; set; }
        public string NumberforEmergencyContact { get; set; }
        public string SocialMediaConnectionName { get; set; }
        public string SocialMediaConnectionAddress { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual District District { get; set; }
        // department
    
    }
}
