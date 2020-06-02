using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class RequestForVisaDTO
    {
        public int Id { get; set; }
        public string Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }

        public DateTime TripStart { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripStartTime { get; set; }

        public DateTime TripEnd { get; set; }
        public DateTime TripEndDate { get; set; }
        public DateTime TripEndTime { get; set; }

        public string TripCountry { get; set; }

        public VisaTypeDTO VisaType { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
