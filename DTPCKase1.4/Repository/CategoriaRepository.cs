using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using System.Linq.Expressions;

namespace DTPCKase1._4.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Categoria obj)
        {
            _db.Categorias.Update(obj);
        }
    }
}
