using HospitalApp.Areas.Identity.Data;
using HospitalApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.ViewModels;
using HospitalApp.Models;

namespace HospitalApp.Controllers
{
    [Authorize(Roles = "Doctor, Admin")]
    public class DoctorController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<DoctorController> _logger;
        private readonly UserManager<User> _userManager;
        public DoctorController(ILogger<DoctorController> logger, UserManager<User> userManager,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public ActionResult ViewPatients(int pageNumber = 1)
        {
            int pageSize = 3;
            string userId = _userManager.GetUserId(User);
            var Doctor = _unitOfWork.doctorService.GetByUserAccount(userId);
            if(Doctor != null)
            {
                
                return View( PaginatedList<Patient>.Create(_unitOfWork.patientService.GetDistinctPatientsByDoctorId(Doctor.Id),pageNumber,pageSize));

            }
            else
            {
                return View();
            }
        }
    }
}
