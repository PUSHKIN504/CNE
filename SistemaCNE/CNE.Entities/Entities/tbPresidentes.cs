﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CNE.Entities.Entities
{
    public partial class tbPresidentes
    {
        public tbPresidentes()
        {
            tbVotos = new HashSet<tbVotos>();
        }

        public int Pre_Id { get; set; }
        public int? Pre_Votos { get; set; }
        public string Pre_ImgUrl { get; set; }
        public int Pre_UsuarioCreacion { get; set; }
        public DateTime Pre_FechaCreacion { get; set; }
        public int? Pre_UsuarioModificacion { get; set; }
        public DateTime? Pre_FechaModificacion { get; set; }
        public bool? Pre_Estado { get; set; }
        public int? Par_id { get; set; }
        [NotMapped]
        public string Par_ImgUrl { get; set; }
        [NotMapped]
        public string Per_Nombre { get; set; }
        [NotMapped]
        public string Per_Apellido { get; set; }
        public virtual tbPartidos Par { get; set; }
        public virtual tbPersonas Pre { get; set; }
        public virtual tbUsuarios Pre_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Pre_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbVotos> tbVotos { get; set; }
    }
}