using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using DTPCKase1._4.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DTPCKase1._4.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class ProductoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductoController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Producto> objProductoList = _unitOfWork.Producto.GetAll(includeProperties:"Categoria").ToList();

            return View(objProductoList);

        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoriaList = _unitOfWork.Categoria
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.nom_categoria,
                    Value = u.Id.ToString()
                }),
                Producto = new Producto()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Producto = _unitOfWork.Producto.Get(u => u.Id == id);
                return View(productVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\producto");

                    if (!string.IsNullOrEmpty(productVM.Producto.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, productVM.Producto.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Producto.ImageUrl = @"\images\producto\" + fileName;
                }
                if (productVM.Producto.Id == 0)
                {
                    _unitOfWork.Producto.Add(productVM.Producto);
                }
                else
                {
                    _unitOfWork.Producto.Update(productVM.Producto);
                }

                _unitOfWork.Save();
                TempData["success"] = "Producto creado";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoriaList = _unitOfWork.Categoria
              .GetAll().Select(u => new SelectListItem
              {
                  Text = u.nom_categoria,
                  Value = u.Id.ToString()
              });
                return View(productVM);

            }

        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Producto? productoFromDb = _unitOfWork.Producto.Get(u => u.Id == id);
        //    if (productoFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productoFromDb);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Producto? obj = _unitOfWork.Producto.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Producto.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Producto  Eliminada exitosamente";
        //    return RedirectToAction("Index");

        //    return View();
        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Producto> objProductoList = _unitOfWork.Producto.GetAll(includeProperties: "Categoria").ToList();
            return Json(new { data = objProductoList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Producto.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new {success= false, message= "Error Eliminando Item"});
            }

            var oldImagePath =
                            Path.Combine(_webHostEnvironment.WebRootPath, 
                            productToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);

            }

            _unitOfWork.Producto.Remove(productToBeDeleted);
            _unitOfWork.Save();
            List<Producto> objProductoList = _unitOfWork.Producto.GetAll(includeProperties: "Categoria").ToList();
            return Json(new { success = true, message ="Producto Eliminado" });

        }

        #endregion
    }
}




            //public IActionResult Edit(int? id)
            //{
            //    if(id==null || id == 0)
            //    {
            //        return NotFound();
            //    }
            //    Producto? productoFromDb = _unitOfWork.Producto.Get(u => u.Id == id);
            //    if(productoFromDb == null) 
            //    {
            //        return NotFound(); 
            //    }

//    return View(productoFromDb);
//}
//[HttpPost]
//public IActionResult Edit(Producto obj)
//{
//    if (ModelState.IsValid)
//    {
//        _unitOfWork.Producto.Update(obj);
//        _unitOfWork.Save();
//        return RedirectToAction("Index");
//    }
//    return View();
//}



