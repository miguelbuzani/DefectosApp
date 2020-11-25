using Sistema_de_Errores.Filters;
using System.Web;
using System.Web.Mvc;

namespace Sistema_de_Errores
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginFilter());
        }
    }
}
