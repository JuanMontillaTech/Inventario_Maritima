using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MGI_Maritima.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MGI_Maritima.Controllers.Invenatario
{
    public class InventarioController : Controller
    {
        private readonly InventarioContext _db; 
        public InventarioController(InventarioContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reporte()
        {
            return View();
        }
        #region Mis_Api
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Json(new { data = await _db.logInventarios.ToListAsync() });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             
            return Json(new { data = await _db.inventarios.ToListAsync() });
        }
  
        [HttpPost]
        public async Task<IActionResult> PostInvenario(string data)
        {
            try
            {
                string _accion = "";
               
                var inventario = JsonConvert.DeserializeObject<InventarioData>(data);
                var finventario = await _db.inventarios.Where(x => x.idalmacen == inventario.idalmacen && x.idarticulo == inventario.idarticulo).FirstOrDefaultAsync();
                if (finventario != null)
                {
                    if (inventario.Accion == 1)
                    {
                        finventario.cantidad += inventario.cantidad;
                        _accion = "Entro";
                    }
                    else
                    {
                        finventario.cantidad -= inventario.cantidad;
                        _accion = "Salio";
                    }

                }
                else
                {
                    _accion = "Entro";
                    _db.inventarios.Add(new Inventario() {  idalmacen = inventario.idalmacen, idarticulo= inventario.idarticulo, cantidad = inventario.cantidad});
                }
                _db.logInventarios.Add(new LogInventario() { 
                    idarticulo = inventario.idarticulo, 
                    idubicacion = inventario.idalmacen, 
                    fecha = DateTime.Now, 
                    detalle = string.Format("El Articulo {0} {1} en el Almacen {2} la fecha {3}", GetNameArticulo(inventario.idarticulo), _accion, GetNameAlmacen(inventario.idalmacen), DateTime.Now.ToString()) });
               
                await _db.SaveChangesAsync();
                return Json(new { success = true, message = "Guardado" });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, message = "No pudo guardar" });
            }
                
           
        }
        public   string GetNameArticulo(int? id)
        {
            Models.Articulo articulof =  _db.articulos.Find(id);
            return articulof.nombre;

        }
        public string GetNameAlmacen(int? id)
        {
            Models.Almacen  almacen =  _db.almacens.Find(id);
            return almacen.descripcion;

        }


        #endregion
    }
}