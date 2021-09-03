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
    public class DoctorService : IDoctorService
    {
        private DBContext _context;

        public DoctorService(DBContext context)
        {
            _context = context;
        }
        public Doctor GetById(int id)
        {
            var Doctor = _context.Doctors.Find(id);
            return Doctor;
        }
        public List<Doctor> GetDoctors()
        {
            var allDoctors = _context.Doctors.ToList();
            return allDoctors;
        }
        public List<Doctor> GetDoctorsWithAppointments()
        {
            var allDoctors = _context.Doctors.Include(a => a.Appointments).ToList();
            return allDoctors;
        }
        public Doctor GetByUserAccount(string id)
        {
            var Doctor = _context.Doctors.Where(a => a.UserAccount == id).FirstOrDefault();
            return Doctor;
        }
    }
}
