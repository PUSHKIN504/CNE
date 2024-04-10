﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CNE.Entities.Entities
{
    public partial class tbPersonas
    {
        public int Per_Id { get; set; }
        public string Per_Nombre { get; set; }
        [NotMapped]
        public int Edad { get; set; }
        public string Per_Apellido { get; set; }
        public DateTime Per_FechaNacimiento { get; set; }
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

        public virtual tbEstadosCiviles EsC { get; set; }
        public virtual tbMesas Mes { get; set; }
        public virtual tbMunicipios Mun { get; set; }
        public virtual tbUsuarios Per_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Per_UsuarioModificacionNavigation { get; set; }
        public virtual tbAlcaldes tbAlcaldes { get; set; }
        public virtual tbDiputados tbDiputados { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
        public virtual tbPresidentes tbPresidentes { get; set; }
    }
}