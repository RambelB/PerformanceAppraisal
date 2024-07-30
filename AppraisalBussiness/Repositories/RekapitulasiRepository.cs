using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class RekapitulasiRepository : IRekapitulasiRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;
        public RekapitulasiRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Rekapitulasi model)
        {
            _dbContext.Rekapitulasis.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(Rekapitulasi model)
        {
            throw new NotImplementedException();
        }
    }
}
