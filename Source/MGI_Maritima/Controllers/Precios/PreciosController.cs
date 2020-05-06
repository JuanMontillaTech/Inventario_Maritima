using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGI_Maritima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MGI_Maritima.Controllers.Precios
{
    public class PreciosController : Controller
    {
        private readonly InventarioContext _db;
       
        public PreciosController(InventarioContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        #region Mis_Api
      
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Json(new { data = await _db.precios.Where(x => x.idArticulo == id).ToListAsync() });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var precioFromDB = await _db.precios.FirstOrDefaultAsync(x => x.id == id);
            if (precioFromDB == null)
            {
                return Json(new { success = false, message = "Error Eliminando" });

            }
            _db.precios.Remove(precioFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado" });

        }

        #endregion

    }
}