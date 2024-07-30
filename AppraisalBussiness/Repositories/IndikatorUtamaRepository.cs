using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class IndikatorUtamaRepository : IIndikatorUtamaRepository
    {
        private readonly PerformanceAppraisalContext _context;
        public IndikatorUtamaRepository(PerformanceAppraisalContext context)
        {
            _context = context;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IndikatorUtamaKerja model)
        {
            _context.IndikatorUtamaKerjas.Add(model);
            _context.SaveChanges();
        }

        public void Update(IndikatorUtamaKerja model)
        {
            throw new NotImplementedException();
        }
    }
}
