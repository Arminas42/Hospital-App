using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ExpirationDate{ get; set; }
    }
}
