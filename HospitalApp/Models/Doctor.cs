using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality{ get; set; }
        public string Contacts{ get; set; }
        public string UserAccount{ get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
