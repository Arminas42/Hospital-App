using HospitalApp.Data;
using HospitalApp.Infrastructure;
using HospitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.Services
{
    public class DrugService : IDrugService
    {
        private DBContext _context;

        public DrugService(DBContext context)
        {
            _context = context;
        }
        public List<Drug> SearchDrugs(string term)
        {
            var foundPrescriptions = _context.Drugs.Where(a => a.Name.Contains(term)).ToList();
            return foundPrescriptions;
        }
    }
}
