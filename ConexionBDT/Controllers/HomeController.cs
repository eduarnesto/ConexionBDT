using ConexionBDT.Models;
using DALD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ConexionBDT.Controllers
{
    public class HomeController : Controller
    {
        
        

        

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Conexion()
        {
            try
            {
                ClsConexion _conexion = new ClsConexion();
                using (SqlConnection conexion = _conexion.getConexion())
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        ViewBag.estado = "Conexi�n exitosa";
                    }
                    else
                    {
                        ViewBag.estado = "Error: la conexi�n no pudo establecerse";
                    }
                }
            }
            catch (Exception ex)
            {
               
                ViewBag.estado = "Error al intentar conectar con la base de datos";
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}