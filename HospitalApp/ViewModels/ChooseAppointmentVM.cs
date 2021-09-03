using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.ViewModels
{
    public class ChooseAppointmentVM
    {
        public int DoctorId { get; set; }
        public List<Appointment> Appointments { get; set; }

        
    }
}
