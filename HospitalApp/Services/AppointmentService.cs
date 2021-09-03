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
    public class AppointmentService : IAppointmentService
    {
        private DBContext _context;

        public AppointmentService(DBContext context)
        {
            _context = context;
        }
        public List<Appointment> GetAppointments()
        {
            var allAppointments = _context.Appointments.ToList();
            return allAppointments;
        }
        public List<Appointment> GetAppointmentsByDoctorId(int id)
        {
            var allAppointments = _context.Appointments.Where(a => a.DoctorId == id).Include(x => x.Patient).ToList();
            return allAppointments;
        }
        public Appointment GetById(int id)
        {
            var Appointment = _context.Appointments.Find(id);
            return Appointment;
        }
        public Appointment GetByIdWithPatient(int id)
        {
            var Appointment = _context.Appointments.Where(x => x.Id == id).Include(y => y.Patient).FirstOrDefault();
            return Appointment;
        }
        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }
        public void DeleteAppointment(int id)
        {
            Appointment appointment = _context.Appointments.Find(id);
            _context.Appointments.Remove(appointment);
        }
        public void UpdateAppointment(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
        }
        public bool IsReserved(DateTime dateTime, int DoctorId)
        {
            var answer = _context.Appointments.Where(a => a.DoctorId == DoctorId && a.DateTime == dateTime).FirstOrDefault();
            if (answer == null){
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
