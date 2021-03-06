using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public class Appointment
    {
       
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateTime { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string State { get; set; }
    }
}
