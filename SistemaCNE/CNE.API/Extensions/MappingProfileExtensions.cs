using AutoMapper;
using CNE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNE.Common.Models;

namespace CNE.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<DepartamentoViewModel, tbDepartamentos>().ReverseMap();
            CreateMap<PersonaViewModel, tbPersonas>().ReverseMap();
            CreateMap<PresidenteViewModel, tbPresidentes>().ReverseMap();
            CreateMap<VotoViewModel, tbVotos>().ReverseMap();
            CreateMap<EstadoCivilViewModel, tbEstadosCiviles>().ReverseMap();
            CreateMap<PersonaViewModel, tbPersonas>().ReverseMap();
            CreateMap<CentroVotacionesViewModels, tbCentrosVotaciones>().ReverseMap();
            CreateMap<MesaViewModel, tbMesas>().ReverseMap();
            CreateMap<PantallaViewModel, tbPantallas>().ReverseMap();
            CreateMap<MunicipioViewModel, tbMunicipios>().ReverseMap();
            CreateMap<RolViewModel, tbRoles>().ReverseMap();
            CreateMap<DiputadoViewModel, tbDiputados>().ReverseMap();
            CreateMap<AlcaldeViewModel, tbAlcaldes>().ReverseMap();
            CreateMap<PartidosViewModel, tbPartidos>().ReverseMap();
            CreateMap<UsuarioViewModel, tbUsuarios>().ReverseMap();











        }
    }
}
