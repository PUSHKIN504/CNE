using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class DepartamentoViewModel
    {
        [Display(Name = "Codigo")]
        public string Dep_Id { get; set; }
        [Display(Name = "Departamento")]
        public string Dep_Descripcion { get; set; }
        [Display(Name = "Usuario Creacion")]
        public int Dep_UsuarioCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime Dep_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? Dep_UsuarioModificacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public DateTime? Dep_FechaModificacion { get; set; }
        public bool? Depar_Estado { get; set; }
    }
}
