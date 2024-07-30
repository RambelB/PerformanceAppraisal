using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class KpiRepository : IKpiRepository
    {
        private readonly PerformanceAppraisalContext _context;
        public KpiRepository(PerformanceAppraisalContext context)
        {
            _context = context;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Kpi> GetAll()
        {
            return _context.Kpis.ToList();
        }

        public Kpi GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Kpi model)
        {
            throw new NotImplementedException();
        }

        public void Update(Kpi model)
        {
            throw new NotImplementedException();
        }
    }
}
