using ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Data;
using ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto _iproducto;

        public ProductoController(IProducto iproducto)
        {
            _iproducto = iproducto;
        }

        //Read
        public IActionResult Index()
        {
            var producto = _iproducto.ObtenerProductos();
            return View(producto);
        }

        public IActionResult Detalle(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);
            return View(producto);
        }

        //Create
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            _iproducto.InsertarProducto(producto);
            return RedirectToAction("index");
        }

        //Edit
        public IActionResult Editar(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            _iproducto.ActualizarProducto(producto);
            return RedirectToAction("index");
        }

        //Delete
        public IActionResult Eliminar(int id)
        {
            var producto = _iproducto.ObtenerProductoPorId(id);
            if(producto == null)
                return NotFound();
            return View(producto);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            _iproducto.EliminarProducto(id);
            return RedirectToAction("index");
        }
    }
}
