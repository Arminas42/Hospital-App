using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Models
{
    public class Drug
    {
        public int Id {get; set;}
        public string Name { get; set;}
        public List<Prescription> Prescriptions { get; set; }

    }
}
