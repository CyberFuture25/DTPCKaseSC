using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using System.Linq.Expressions;

namespace DTPCKase1._4.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
