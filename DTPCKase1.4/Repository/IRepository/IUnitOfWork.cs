using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTPCKase1._4.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categoria { get; }
        IProductRepository Producto { get; }

        void Save();
    }
}
