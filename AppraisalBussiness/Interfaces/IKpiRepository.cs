using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IKpiRepository
    {
        public void Insert(Kpi model);
        public void Update(Kpi model);
        public void Delete(string id);
        public List<Kpi> GetAll();
        public Kpi GetById(int id);
    }
}
