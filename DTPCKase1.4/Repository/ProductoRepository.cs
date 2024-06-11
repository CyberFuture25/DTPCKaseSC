using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using System.Linq.Expressions;

namespace DTPCKase1._4.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Producto obj)
        {
            _db.Productos.Update(obj);
        }
    }
}
