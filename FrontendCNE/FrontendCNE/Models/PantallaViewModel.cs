using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
   public class PantallaViewModel
    {

        [Display(Name = "Codigo")]

        public int Panta_Id { get; set; }
                [Display(Name="Descripcion")]

        public string Panta_Descripcion { get; set; }
                [Display(Name="Esquema")]

        public string Panta_Esquema { get; set; }
                [Display(Name="Usuario Crea")]

        public int Panta_UsuarioCreacion { get; set; }
                [Display(Name="Fecha Creacion")]

        public DateTime Panta_FechaCreacion { get; set; }
                [Display(Name="Usu Modifica")]

        public int? Panta_UsuarioModificacion { get; set; }
                [Display(Name="Fecha Modifica")]

        public DateTime? Panta_FechaModificacion { get; set; }
                [Display(Name="Estado")]

        public bool? Panta_Estado { get; set; }
    }
}
