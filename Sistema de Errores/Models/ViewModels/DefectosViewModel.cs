using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_Errores.Models.ViewModels
{
    public class DefectosViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Sucursal")]
        public string sucursal { get; set; }

        [Required]
        [Display(Name = "Supervisor")]
        public string supervisor { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
        public DateTime fechaHora { get; set; }
        public DateTime fecha { get; set; }

    }
}