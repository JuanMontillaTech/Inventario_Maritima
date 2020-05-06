using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGI_Maritima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MGI_Maritima.Controllers.Ubicacion
{
    public class UbicacionController : Controller
    {
        private readonly InventarioContext _db;
        [BindProperty]
        public Almacen   almacen { get; set; }
        public UbicacionController(InventarioContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult UpInsert(int? id)
        {
            almacen = new Almacen();
            if (id == null)
            {
                return View(almacen);
            }
            almacen = _db.almacens.FirstOrDefault(x => x.id == id);
            if (almacen == null)
            {
                return NotFound();
            }
            return View(almacen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpInsert()
        {
            if (ModelState.IsValid)
            {
                if (almacen.id == 0)
                {
                    _db.almacens.Add(almacen);
                }
                else
                {
                    _db.almacens.Update(almacen);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(almacen);
        }



        #region Mis_Api
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.almacens.ToListAsync() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var almacenFromDB = await _db.almacens.FirstOrDefaultAsync(x => x.id == id);
            if (almacenFromDB == null)
            {
                return Json(new { success = false, message = "Error Eliminando" });

            }
            _db.almacens.Remove(almacenFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado" }); 

        }

        #endregion
    }
}