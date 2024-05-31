namespace DTPCKase1._4.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoriaRepository Categoria { get; }
        IProductoRepository Producto { get; }
        void Save();
    }
}
