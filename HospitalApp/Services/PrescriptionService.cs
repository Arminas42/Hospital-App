using HospitalApp.Data;
using HospitalApp.Infrastructure;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private DBContext _context;

        public PrescriptionService(DBContext context)
        {
            _context = context;
        }
        public void AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
        }

        public void DeletePrescription(int id)
        {
            Prescription prescription = _context.Prescriptions.Find(id);
            _context.Prescriptions.Remove(prescription);
        }

        public Prescription GetById(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            return prescription;
        }


        public List<Prescription> GetPrescriptions()
        {
            var allPrescriptions = _context.Prescriptions.OrderByDescending(x => x.DateOfIssue).ToList();
            return allPrescriptions;
        }

        public IQueryable<Prescription> GetPrescriptionsByDoctorIdWithPatient(int id)
        {
            var allPrescriptions = _context.Prescriptions.OrderByDescending(x => x.DateOfIssue).Where(a => a.DoctorId == id).Include(x => x.Patient ).Include(x => x.Drug);
            return allPrescriptions;
        }
        public Prescription GetByIdWithChildren(int id)
        {
            var prescription = _context.Prescriptions.Where(x=>x.Id == id).Include(y => y.Patient).Include(z => z.Drug).Include(z => z.Doctor).FirstOrDefault();
            return prescription;
        }
        public List<Prescription> GetByTabNumber(string Tab_number)
        {
            var prescriptions = _context.Prescriptions.Where(x => x.Patient.Tab_number == Tab_number).Include(y => y.Patient).Include(z => z.Drug).Include(z => z.Doctor).ToList();
            return prescriptions;
        }


    }
}
