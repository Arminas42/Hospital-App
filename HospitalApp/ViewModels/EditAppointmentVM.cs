 using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.ViewModels
{
    public class EditAppointmentVM
    {
        public Appointment Appointment { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public EditAppointmentVM(){ }
        public EditAppointmentVM(Appointment appointment)
        {
            Appointment = appointment;
            Appointment.Patient = appointment.Patient;
            Date = appointment.DateTime.Date;
            Time = Convert.ToString(appointment.DateTime.TimeOfDay).Remove(5);
        }
        public void AddDateTimeToModel(DateTime date, string time)
        {
            DateTime dateTime = date.Add(TimeSpan.Parse(time));

            Appointment.DateTime = dateTime;
        }
        public List<SelectListItem> Times { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "12:00", Text = "12:00" },
            new SelectListItem { Value = "13:00", Text = "13:00" },
            new SelectListItem { Value = "14:00", Text = "14:00" },
            new SelectListItem { Value = "15:00", Text = "15:00" },
            new SelectListItem { Value = "16:00", Text = "16:00" },
            new SelectListItem { Value = "17:00", Text = "17:00" },
           
        };
    }
}
