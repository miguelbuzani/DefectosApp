using Sistema_de_Errores.Controllers;
using Sistema_de_Errores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Errores.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        private Users user;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                user = (Users)HttpContext.Current.Session["Users"];
                if (user == null)
                {
                    if(filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Views/Home/Index");
                    }
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}