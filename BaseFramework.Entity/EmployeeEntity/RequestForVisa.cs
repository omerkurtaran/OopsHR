using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class RequestForVisa
    {
        public RequestForVisa()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Description { get; set; }
        public DateTime TripStart { get; set; }
        public DateTime TripStartDate { get; set; }
        public TimeSpan TripStartTime { get; set; }
        public DateTime TripEnd { get; set; }
        public DateTime TripEndDate { get; set; }
        public TimeSpan TripEndTime { get; set; }
        public string TripCountry { get; set; }

        [ForeignKey("VisaType")]
        public int VisaId { get; set; }
        public VisaType VisaType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
