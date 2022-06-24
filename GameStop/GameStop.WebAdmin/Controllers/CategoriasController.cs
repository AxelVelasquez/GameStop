using GameStop.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStop.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaBL _categoriaBL;

        public CategoriasController()
        {
            _categoriaBL = new CategoriaBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeProductos = _categoriaBL.ObtenerProductos();
            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(categoria);
                }
                _categoriaBL.GuardarProducto(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriaBL.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            _categoriaBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }
        public ActionResult Detalle(int id)
        {
            var producto = _categoriaBL.ObtenerProducto(id);
            return View(producto);
        }
        public ActionResult Eliminar(int id)
        {
            var producto = _categoriaBL.ObtenerProducto(id);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _categoriaBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }



    }
}