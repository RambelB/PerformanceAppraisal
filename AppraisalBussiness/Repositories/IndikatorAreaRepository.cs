using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Repositories
{
    public class IndikatorAreaRepository : IIndikatorAreaRepository
    {
        private readonly PerformanceAppraisalContext _repository;
        public IndikatorAreaRepository(PerformanceAppraisalContext repository)
        {
            _repository = repository;
        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IndikatorArea model)
        {
            _repository.Add(model);
            _repository.SaveChanges();
        }

        public void Update(IndikatorArea model)
        {
            throw new NotImplementedException();
        }
    }
}
