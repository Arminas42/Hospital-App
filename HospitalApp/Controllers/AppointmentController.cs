using HospitalApp.Infrastructure;
using HospitalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers.Appointment
{
    [Authorize(Roles = "Receptionist, Admin")]

    public class AppointmentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SelectDoctor()
        {
            var Doctors = _unitOfWork.doctorService.GetDoctors();
            return View(Doctors);
        }
        public ActionResult ChooseAppointment(int id)
        {
            var ViewModel = new ChooseAppointmentVM()
            {
                Appointments = _unitOfWork.appoinmentService.GetAppointmentsByDoctorId(id),
                DoctorId = id
            };


            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int DoctorId, DateTime Date, string Time)
        {
            DateTime dateTime = Date.Add(TimeSpan.Parse(Time));
            if (_unitOfWork.appoinmentService.IsReserved(dateTime, DoctorId) == true)
            {
                ViewBag.ErrorMessage = "Date and time is already taken";
                return View();
            }
            else
            {
                Models.Appointment ModelAppointment = new()
                {
                    DateTime = dateTime,
                    DoctorId = DoctorId,
                    Patient = null,
                    State = "Reserved"

                };
                _unitOfWork.appoinmentService.AddAppointment(ModelAppointment);
                _unitOfWork.Save();
                return RedirectToAction("Edit", "Appointment", new { id = ModelAppointment.Id });
            }

        }

        public ActionResult Edit(int id)
        {
            var ViewModel = new EditAppointmentVM(_unitOfWork.appoinmentService.GetByIdWithPatient(id));
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DateTime Date, string Time, [Bind("DoctorId,Patient, State")] Models.Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.Id = id;
                appointment.Patient = _unitOfWork.patientService.GetByTabNumber(appointment.Patient.Tab_number);
                appointment.DateTime = Date.Add(TimeSpan.Parse(Time));
                _unitOfWork.appoinmentService.UpdateAppointment(appointment);
                _unitOfWork.Save();
                return RedirectToAction("ChooseAppointment", "Appointment", new {id= appointment.DoctorId });

            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _unitOfWork.appoinmentService.DeleteAppointment(id);
            ViewBag.DeleteMessage = "Appointment succesfully deleted";
            _unitOfWork.Save();
            return View();
            
        }
    }
}
