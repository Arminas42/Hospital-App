using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IUnitOfWork
    {
        IAppointmentService appoinmentService { get; }
        IDoctorService doctorService { get; }
        IPatientService patientService { get; }
        IPrescriptionService prescriptionService { get; }
        IDrugService drugService { get; }
        void Save();
    }
}
