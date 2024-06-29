using DTPCKase1._4.Models;
using DTPCKase1._4.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DTPCKase1._4.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> productoList = _unitOfWork.Producto.GetAll(includeProperties: "Categoria");
            return View(productoList);
        }
        public IActionResult Details(int productoId)
        {
            Producto producto = _unitOfWork.Producto.Get(u =>u.Id== productoId, includeProperties: "Categoria");
            return View(producto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
