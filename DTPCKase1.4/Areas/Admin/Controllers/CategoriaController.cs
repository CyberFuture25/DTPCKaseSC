using DTPCKase1._4.Models;
using Microsoft.AspNetCore.Mvc;

namespace DTPCKase1._4.Areas.Admin.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Categoria> objCategoriaList = _db.Categorias.ToList();
            return View(objCategoriaList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
