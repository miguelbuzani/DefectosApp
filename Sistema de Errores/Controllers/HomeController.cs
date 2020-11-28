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
            return View();
        }

        [HttpPost]
        public ActionResult Index(string User, string Pass)
        {
            using (SistemadeDefectosEntitiesUsr db = new SistemadeDefectosEntitiesUsr())
            {
                var user = db.Users.FirstOrDefault(a => a.name == User && a.pass == Pass);

                if (user != null)
                {
                    Session["Users"] = user;
                    
                    return Redirect("~/Home/Errores");
                }
                else
                {
                    return View();
                }
                
            } 
        }

        public ActionResult Errores()
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
                    return Redirect("~/Home/Errores");
                }

            }catch(Exception e)
            {

            }
            return View();
        }

        public ActionResult Graficas()
        {

            List<Defectos> lista = new List<Defectos>();

            using (SistemadeDefectosEntities db = new SistemadeDefectosEntities())
            {
                lista = db.Defectos.OrderBy(a => a.fecha).ToList();
                
            }
            var wea = lista.GroupBy(def => def.fecha, def => def.fecha, (baseDateE, dateE) => new
            {
                Key = baseDateE,
                total = dateE.Count()
            }).Select(x => new GData() {
                fecha = x.Key,
                total = x.total
            }).ToList();

            return View(wea);
        }
    }
}