using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IPatientService
    {
        Patient GetById(int id);
        Patient GetByTabNumber(string Tab_Number);
        List<Patient> GetPatients();
        IQueryable<Patient> GetDistinctPatientsByDoctorId(int id);
        public List<Patient> SearchPatients(string term);


    }
}
