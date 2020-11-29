using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Errores.Models.ViewModels
{
    public class Errores
    {
        public int id { get; set; }
        public string sucursal { get; set; }
        public string supervisor { get; set; }
        public string categoria { get; set; }
        public System.DateTime fechaHora { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }

    }
}