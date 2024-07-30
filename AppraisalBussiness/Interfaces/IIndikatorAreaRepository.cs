using AppraisalDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IIndikatorAreaRepository
    {
        public void Insert(IndikatorArea model);
        public void Update(IndikatorArea model);
        public void Delete(string id);
    }
}
