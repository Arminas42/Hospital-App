using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointments();
        List<Appointment> GetAppointmentsByDoctorId(int id);

        Appointment GetById(int id);
        Appointment GetByIdWithPatient(int id);
        public void AddAppointment(Appointment appointment);
        public void DeleteAppointment(int id);
        public void UpdateAppointment(Appointment appointment);
        public bool IsReserved(DateTime dateTime, int DoctorId);

    }
}
