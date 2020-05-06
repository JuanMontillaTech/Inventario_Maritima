using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGI_Maritima.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MGI_Maritima.Controllers.Articulo
{
    public class ArticuloController : Controller
    {
        private readonly InventarioContext _db;
        [BindProperty]
        public Models.Articulo articulo { get; set; }
        public ArticuloController(InventarioContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpInsert(int? id)
        {
            articulo = new Models.Articulo();
            if (id == null)
            {

                return View(articulo);
            }

            articulo = _db.articulos.FirstOrDefault(x => x.id == id);
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpInsert(IFormCollection data)
        {

            var json = data["DataPrecio"];
            List<DataPrecio> dataPrecios = JsonConvert.DeserializeObject<List<DataPrecio>>(json);
            if (ModelState.IsValid)
            {
                if (articulo.id == 0)
                {
                    _db.articulos.Add(articulo);
                }
                else
                {
                    _db.articulos.Update(articulo);
                }
                _db.SaveChanges();
                var _PreciosArticulos = _db.precios.Where(x => x.idArticulo == articulo.id).ToList();
                _db.precios.RemoveRange(_PreciosArticulos);
                _db.SaveChanges();
                if (dataPrecios != null)
                {
                    foreach (DataPrecio item in dataPrecios)
                    {

                        _db.precios.Add(new Precio() { id = 0, idArticulo = articulo.id, precio = item.precio });
                        _db.SaveChanges();

                    }
                }

                return RedirectToAction("Index");
            }
            return View(articulo);
        }



        #region Mis_Api
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Json(new { data = await _db.articulos.ToListAsync() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var articuloFromDB = await _db.articulos.FirstOrDefaultAsync(x => x.id == id);
            if (articuloFromDB == null)
            {
                return Json(new { success = false, message = "Error Eliminando" });

            }
            var _PreciosArticulos = _db.precios.Where(x => x.idArticulo == articuloFromDB.id).ToList();
            _db.precios.RemoveRange(_PreciosArticulos);
            _db.SaveChanges();
            _db.articulos.Remove(articuloFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado" });

        }

        #endregion
    }
}