using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class PerubahanNilaiRepository : IPerubahanNilaiRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;
        public PerubahanNilaiRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PerubahanNilai model)
        {
            _dbContext.PerubahanNilais.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(PerubahanNilai model)
        {
            throw new NotImplementedException();
        }
    }
}
