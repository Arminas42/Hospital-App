using HospitalApp.Data;
using HospitalApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    //explained https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext _context;
        private IAppointmentService _appointmentService;
        private IDoctorService _doctorService;
        private IPatientService _patientService;
        private IPrescriptionService _prescriptionService; 
        private IDrugService _drugService;
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        public IAppointmentService appoinmentService
        {
            get
            {
                return _appointmentService = _appointmentService ?? new AppointmentService(_context);
            }
        }
        public IDoctorService doctorService
        {
            get
            {
                return _doctorService = _doctorService ?? new DoctorService(_context);
            }
        }
        public IPatientService patientService
        {
            get
            {
                return _patientService = _patientService ?? new PatientService(_context);
            }
        }
        public IPrescriptionService prescriptionService
        {
            get
            {
                return _prescriptionService = _prescriptionService ?? new PrescriptionService(_context);
            }
        }
        public IDrugService drugService
        {
            get
            {
                return _drugService = _drugService ?? new DrugService(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
