﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace CNE.Entities.Entities
{
    public partial class tbCentrosVotaciones
    {
        public tbCentrosVotaciones()
        {
            tbMesas = new HashSet<tbMesas>();
        }

        public int CeV_Id { get; set; }
        public string Mun_Id { get; set; }
        public int CeV_UsuarioCreacion { get; set; }
        public DateTime CeV_FechaCreacion { get; set; }
        public int? CeV_UsuarioModificacion { get; set; }
        public DateTime? CeV_FechaModificacion { get; set; }
        public bool? CeV_Estado { get; set; }
        public string CeV_Nombre { get; set; }

        public virtual tbUsuarios CeV_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios CeV_UsuarioModificacionNavigation { get; set; }
        public virtual tbMunicipios Mun { get; set; }
        public virtual ICollection<tbMesas> tbMesas { get; set; }
    }
}