using System;
using System.ComponentModel.DataAnnotations;

namespace FrontendCNE.Models
{
    public class EstadoCivilViewModel
    {
        [Display(Name = "Id")]

        public int EsC_Id { get; set; }
        [Display(Name = "Descripcion")]

        public string EsC_Descripcion { get; set; }
        public int EsC_UsuarioCreacion { get; set; }
        public DateTime EsC_FechaCreacion { get; set; }
        public int? EsC_UsuarioModificacion { get; set; }
        public DateTime? EsC_FechaModificacion { get; set; }
        public bool? EsC_Estado { get; set; }



    }
}
