using HospitalApp.Data;
using HospitalApp.Infrastructure;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class PatientService : IPatientService
    {
        private DBContext _context;

        public PatientService(DBContext context)
        {
            _context = context;
        }
        public Patient GetById(int id)
        {
            var Patient = _context.Patients.Find(id);
            return Patient;
        }
        public Patient GetByTabNumber(string Tab_Number)
        {
            var Patient = _context.Patients.Where(x => x.Tab_number == Tab_Number).FirstOrDefault();
            return Patient;
        }

        public List<Patient> GetPatients()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> GetDistinctPatientsByDoctorId(int id)
        {
            var Patients = (from p in _context.Patients 
                            from a in _context.Appointments
                            where p.Id == a.Patient.Id && a.DoctorId == id
                            select p ).Distinct() ;
            return Patients;
        }
        public List<Patient> SearchPatients(string term)
        {
            var foundPatients = _context.Patients.Where(a => a.Tab_number.Contains(term)).ToList();
            return foundPatients;
        }

    }
}
