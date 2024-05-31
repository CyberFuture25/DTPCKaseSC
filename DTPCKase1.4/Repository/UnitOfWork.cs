using DTPCKase1._4.Repository.IRepository;

namespace DTPCKase1._4.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoriaRepository Categoria { get; private set; }
        public IProductoRepository Producto { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Producto = new ProductoRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
