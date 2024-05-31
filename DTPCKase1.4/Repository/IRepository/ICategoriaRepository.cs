using DTPCKase1._4.Models;

namespace DTPCKase1._4.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria obj);
        void Save();
    }
}
