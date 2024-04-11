using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Models
{
    public class PersonasViewModel
    {
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Per_Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Per_Nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Per_Apellido { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Per_FechaNacimiento { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Per_Sexo { get; set; }
        [Display(Name = "Edad")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [NotMapped]
        public int Edad { get; set; }
        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Per_CedulaIdentidad { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Per_Direccion { get; set; }
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string Mun_Id { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]

        public string Per_Telefono { get; set; }
        [Display(Name = "Usuario Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Per_UsuarioCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime Per_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]

        public int? Per_UsuarioModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime? Per_FechaModificacion { get; set; }
        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? EsC_Id { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Per_Estado { get; set; }
        [Display(Name = "Mesa")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Mes_Mesa { get; set; }
        [Display(Name = "Mesa")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int? Mes_Id { get; set; }
        [Display(Name = "Voto")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public bool? Per_Voto { get; set; }

    }
}
