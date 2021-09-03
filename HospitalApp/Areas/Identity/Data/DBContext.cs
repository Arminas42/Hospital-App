using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Data
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<HospitalApp.Models.Appointment> Appointments { get; set; }
        public DbSet<HospitalApp.Models.Doctor> Doctors{ get; set; }
        public DbSet<HospitalApp.Models.Patient> Patients{ get; set; }
        public DbSet<HospitalApp.Models.Prescription> Prescriptions{ get; set; }
        public DbSet<HospitalApp.Models.Drug> Drugs{ get; set; }

    }
}
