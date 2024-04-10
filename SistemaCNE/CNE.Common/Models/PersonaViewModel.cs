using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.Common.Models
{
    public class PersonaViewModel
    {
        public int Per_Id { get; set; }
        public string Per_Nombre { get; set; }
        public string Per_Apellido { get; set; }
        public DateTime Per_FechaNacimiento { get; set; }
        [NotMapped]
        public int Edad { get; set; }

        public string Per_Sexo { get; set; }
        public string Per_CedulaIdentidad { get; set; }
        public string Per_Direccion { get; set; }
        public string Mun_Id { get; set; }
        public string Per_Telefono { get; set; }
        public int Per_UsuarioCreacion { get; set; }
        public DateTime Per_FechaCreacion { get; set; }
        public int? Per_UsuarioModificacion { get; set; }
        public DateTime? Per_FechaModificacion { get; set; }
        public int? EsC_Id { get; set; }
        public bool? Per_Estado { get; set; }
        public int Mes_Mesa { get; set; }
        public int? Mes_Id { get; set; }
        public bool? Per_Voto { get; set; }
        [NotMapped]
        public string Pre_ImgUrl { get; set; }
        [NotMapped]
        public string Par_ImgUrl { get; set; }

    }
}
