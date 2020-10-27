using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Errores.Models.ViewModels
{
    public class DefectosViewModel
    {
        public int id { get; set; }
        public string sucursal { get; set; }
        public string supervisor { get; set; }
        public string categoria { get; set; }
        public DateTime fechaHora { get; set; }
        public DateTime fecha { get; set; }

    }
}