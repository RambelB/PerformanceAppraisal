using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class KompetensiDasarRepository : IKompetensiDasarRepository
    {
        private readonly PerformanceAppraisalContext _context;

        public KompetensiDasarRepository(PerformanceAppraisalContext context)
        {
            _context = context;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(KompetensiDasar model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Update(KompetensiDasar model)
        {
            throw new NotImplementedException();
        }
    }
}
