using DTPCKase1._4.Models;
namespace DTPCKase1._4.Repository.IRepository
{
    public interface IProductRepository : IRepository<Producto>
    {
        void Update(Producto obj);
    }
}
