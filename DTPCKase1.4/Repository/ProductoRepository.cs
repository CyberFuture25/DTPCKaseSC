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
            var objFromDb = _db.Productos.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.nom_prod = obj.nom_prod;
                objFromDb.desc_prod = obj.desc_prod;
                objFromDb.stck_prod = obj.stck_prod;
                objFromDb.prec_prod = obj.prec_prod;
                objFromDb.CategoriaId = obj.CategoriaId;

                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;

                }
            }
        }
    }
}
