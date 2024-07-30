using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;

namespace AppraisalBussiness.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PerformanceAppraisalContext _dbContext;
        public UserRepository(PerformanceAppraisalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> getAll(int page, int pageSize)
        {
            return _dbContext.Users.Where(x=>x.Jabatan=="Karyawan").Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public bool isEvaluated(int nik)
        {
            return _dbContext.Rekapitulasis.Any(x => x.Nik == nik);
        }

        public User get(int nik)
        {
            return _dbContext.Users.Find(nik);
        }

        public int count()
        {
            return _dbContext.Users.Count();
        }

        public void insert(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public void update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
        public void delete(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
