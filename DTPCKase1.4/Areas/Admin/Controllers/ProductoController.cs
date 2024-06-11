using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DTPCKase1._4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Producto> objProductoList = _unitOfWork.Producto.GetAll().ToList();
            return View(objProductoList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Producto creado exitosamente";
                return RedirectToAction("Index");
            }
           return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Producto? productoFromDb = _unitOfWork.Producto.Get(u => u.Id == id);
            if(productoFromDb == null) 
            {
                return NotFound(); 
            }

            return View(productoFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Producto obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Producto? productoFromDb = _unitOfWork.Producto.Get(u => u.Id == id);
            if (productoFromDb == null)
            {
                return NotFound();
            }

            return View(productoFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Producto? obj = _unitOfWork.Producto.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Producto.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Producto  Eliminada exitosamente";
            return RedirectToAction("Index");

            return View();
        }


    }
}
