using DTPCKase1._4.Repository.IRepository;

namespace DTPCKase1._4.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;
        public ICategoryRepository Categoria { get; private set; }
        public IProductRepository Producto { get; private set; }
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
