using GameStop.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStop.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        CategoriasBL _categoriasBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var Categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.ListaCategorias = new SelectList(Categorias, "Id", "Descripción");
            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }
                    _productosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripción");
            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }
                _productosBL.GuardarProducto(producto);
                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripción", producto.CategoriaId);
            return View(producto);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);


            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

           

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);
            return RedirectToAction("Index");
        }
    }
}