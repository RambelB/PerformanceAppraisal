using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IIndikatorUtamaRepository
    {
        public void Insert(IndikatorUtamaKerja model);
        public void Update(IndikatorUtamaKerja model);
        public void Delete(string id);
    }
}
