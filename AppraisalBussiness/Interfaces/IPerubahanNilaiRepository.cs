using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IPerubahanNilaiRepository
    {
        public void Insert(PerubahanNilai model);
        public void Update(PerubahanNilai model);
        public void Delete(string id);
    }
}
