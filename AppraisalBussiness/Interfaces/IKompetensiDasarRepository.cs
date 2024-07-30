using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IKompetensiDasarRepository
    {
        public void Insert(KompetensiDasar model);
        public void Update(KompetensiDasar model);
        public void Delete(string id);
    }
}
