using AppraisalDataAccess.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalBussiness.Interfaces
{
    public interface IRekapitulasiRepository
    {
        public void Insert(Rekapitulasi model);
        public void Update(Rekapitulasi model);
        public void Delete(string id);
    }
}
