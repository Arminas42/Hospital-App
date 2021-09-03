using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IPrescriptionService
    {
        Prescription GetById(int id);
        List<Prescription> GetPrescriptions();
        IQueryable<Prescription> GetPrescriptionsByDoctorIdWithPatient(int id);
        public List<Prescription> GetByTabNumber(string Tab_number);
        public void AddPrescription(Prescription prescription);
        public void DeletePrescription(int id);
        public Prescription GetByIdWithChildren(int id);


    }
}
