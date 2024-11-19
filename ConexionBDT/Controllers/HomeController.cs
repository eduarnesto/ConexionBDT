using ConexionBDT.Models;
using DALD;
using ENT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ConexionBDT.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<ClsPersona> list = new List<ClsPersona>();
            try
            {
                list = ListadosDAL.ListadoCompletoPersonasDAL();
            }
            catch (Exception ex)
            {
                //TODO Pagina de errror
            }
            return View(list);
        }

        public IActionResult Delete(int id)
        {
            ClsPersona persona = new ClsPersona();
            try
            {
                persona = ListadosDAL.BuscarPersonaPorId(id);
            }
            catch (Exception ex)
            {
                //TODO Pagina de error
            }
            return View(persona);
        }

        [HttpPost]
        public IActionResult OnDelete(int id)
        {
            string pagina = "";
            try
            {
                ListadosDAL.eliminarPersona(id);
                pagina = "Index";
            }
            catch (Exception ex)
            {
                pagina = "Error";
            }
            return RedirectToAction(pagina);
        }

        [HttpPost]
        public ActionResult Conexion()
        {

            SqlConnection conexion = new SqlConnection(); 
                try
            {
                conexion = ClsConexion.getConexion();

                
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        ViewBag.estado = "Conexión exitosa";
                    }
                    else
                    {
                        ViewBag.estado = "Error: la conexión no pudo establecerse";
                    }
                    
                
            }
            catch (Exception ex)
            {
               
                ViewBag.estado = "Error al intentar conectar con la base de datos";
            }
            finally
            {
                conexion.Close();
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
