using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IDoctorService
    {
        List<Doctor> GetDoctors();
        List<Doctor> GetDoctorsWithAppointments();
        Doctor GetById(int id);
        public Doctor GetByUserAccount(string id);



    }
}
