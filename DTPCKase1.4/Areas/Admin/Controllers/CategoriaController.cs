using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DTPCKase1._4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Categoria> objCategoriaList = _unitOfWork.Categoria.GetAll().ToList();
            return View(objCategoriaList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria obj)
        {
            if (obj.nom_categoria == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("nom_categoria", "El DisplayOrder no puede ser igual al nombre de categoria.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Categoria creada exitosamente";
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
            Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
            if(categoriaFromDb == null) 
            {
                return NotFound(); 
            }

            return View(categoriaFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Categoria obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categoria.Update(obj);
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
            Categoria? categoriaFromDb = _unitOfWork.Categoria.Get(u => u.Id == id);
            if (categoriaFromDb == null)
            {
                return NotFound();
            }

            return View(categoriaFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categoria? obj = _unitOfWork.Categoria.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Categoria.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Categoria  Eliminada exitosamente";
            return RedirectToAction("Index");

            return View();
        }


    }
}
