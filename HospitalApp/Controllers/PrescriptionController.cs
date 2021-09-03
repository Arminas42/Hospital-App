using HospitalApp.Areas.Identity.Data;
using HospitalApp.Infrastructure;
using HospitalApp.Models;
using HospitalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [Authorize(Roles = "Doctor, Admin")]
    public class PrescriptionController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<DoctorController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        public PrescriptionController(ILogger<DoctorController> logger, UserManager<User> userManager, IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _logger = logger;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public ActionResult Index(int pageNumber = 1)
        {
            int pageSize = 3;
            string userId = _userManager.GetUserId(User);
            var Doctor = _unitOfWork.doctorService.GetByUserAccount(userId);
            if (Doctor != null)
            {

                return View(PaginatedList<Prescription>.Create(_unitOfWork.prescriptionService.GetPrescriptionsByDoctorIdWithPatient(Doctor.Id), pageNumber, pageSize));

            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult View(int id)
        {
            var prescription = _unitOfWork.prescriptionService.GetByIdWithChildren(id);
            return View(prescription);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("PatientId, DrugId, ExpirationDate")] Models.Prescription prescription)
        {
            string userId = _userManager.GetUserId(User);
            var Doctor = _unitOfWork.doctorService.GetByUserAccount(userId);
            if (ModelState.IsValid)
            {

                prescription.DateOfIssue = DateTime.Now;
                prescription.DoctorId = Doctor.Id;
                _unitOfWork.prescriptionService.AddPrescription(prescription);
                _unitOfWork.Save();
                //sendEmailAboutPrescription(prescription.Id);
                ViewBag.ErrorMessage = "Prescription created succesfully";
                return RedirectToAction("Index", "Prescription");
            }
            else
            {
                return View();
            }
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var prescription = _unitOfWork.prescriptionService.GetById(id);
            var result =(DateTime.Now - prescription.DateOfIssue).TotalHours;
            if (result < 1)
            {
                _unitOfWork.prescriptionService.DeletePrescription(id);
                _unitOfWork.Save();
                TempData["Message"] = "Prescription deleted succesfully";
                return RedirectToAction("Index", "Prescription", ViewBag.ErrorMessage);
            }
            else
            {
                TempData["Message"] = "Prescription cant be deleted";
                return RedirectToAction("Index","Prescription", ViewBag.ErrorMessage);
            }
        }
        [HttpGet]
        public ActionResult SearchDrug(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var result = _unitOfWork.drugService.SearchDrugs(term);
                return Json(result);
            }
            else
            {
                return Ok();
            }
        }
        [HttpGet]
        public ActionResult SearchPatient(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                var result = _unitOfWork.patientService.SearchPatients(term);
                return Json(result);
            }
            else
            {
                return Ok();
            }
        }

        public void sendEmailAboutPrescription(int id)
        {
            var prescription = _unitOfWork.prescriptionService.GetByIdWithChildren(id);
            _emailSender.SendEmailAsync(
                    prescription.Patient.Email,
                    "Prescription of " + prescription.Drug.Name,
                    "Your prescription of " + prescription.Drug.Name + " <br/> which was issued: " + prescription.DateOfIssue);

        }
    }
}
