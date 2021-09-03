using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Infrastructure
{
    public interface IDrugService
    {
        public List<Drug> SearchDrugs(string term);

    }
}
