using DTPCKase1._4.Models;

namespace DTPCKase1._4.Repository.IRepository
{
    public interface IProductoRepository : IRepository<Producto>
    {
        void Save();
        void Update(Producto obj);
    }
}
