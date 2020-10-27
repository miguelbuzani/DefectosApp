using Sistema_de_Errores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Errores.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Defectos> lista = new List<Defectos>();
            using (SistemadeDefectosEntities db = new SistemadeDefectosEntities())
            {
                 lista = db.Defectos.OrderBy(a =>a.sucursal).ToList();
            }

            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Defectos modelo)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (SistemadeDefectosEntities db = new SistemadeDefectosEntities())
                    {
                        DateTime currentT = DateTime.Now;
                        Defectos tempDefecto = new Defectos();
                        tempDefecto.sucursal = modelo.sucursal;
                        tempDefecto.supervisor = modelo.supervisor;
                        tempDefecto.categoria = modelo.categoria;
                        tempDefecto.fechaHora = currentT;
                        tempDefecto.fecha = currentT.Date;
                        tempDefecto.hora = currentT.TimeOfDay;

                        db.Defectos.Add(tempDefecto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Home/Index");
                }

            }catch(Exception e)
            {

            }
            return View();
        }
    }
}