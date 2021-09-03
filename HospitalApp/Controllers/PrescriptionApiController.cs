using HospitalApp.Attributes;
using HospitalApp.Infrastructure;
using HospitalApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionApiController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public PrescriptionApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        [HttpGet]
        public  ActionResult<IEnumerable<Prescription>> GetPrescriptions()
        {
            return _unitOfWork.prescriptionService.GetPrescriptions();
        }
        [AllowAnonymous]
        [HttpGet("{Tab_number}")]
        public ActionResult<IEnumerable<Prescription>> GetPrescriptionsByTabNumber(string Tab_number)
        {
            return _unitOfWork.prescriptionService.GetByTabNumber(Tab_number);
        }
    }
}
