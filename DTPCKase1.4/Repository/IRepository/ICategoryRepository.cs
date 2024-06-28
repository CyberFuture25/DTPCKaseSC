using DTPCKase1._4.Models;
namespace DTPCKase1._4.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Categoria>
    {
        void Update(Categoria obj);
    }
}
