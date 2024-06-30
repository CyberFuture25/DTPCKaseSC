using DTPCKase1._4.Models;
namespace DTPCKase1._4.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
