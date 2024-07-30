using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalDataAccess.Models;

namespace AppraisalBussiness.Interfaces
{
    public interface IUserRepository
    {
        public void insert(User user);
        public void update(User user);
        public void delete(User user);
        public User get(int nik);
        public int count();
        public List<User> getAll(int page, int pageSize);
        public bool isEvaluated(int nik);
    }
}
