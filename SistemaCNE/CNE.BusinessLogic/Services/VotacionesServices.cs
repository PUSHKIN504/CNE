using CNE.DataAccess.Repository;
using CNE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNE.BusinessLogic.Services
{
    public class VotacionesServices
    {
        private readonly PresidenteRepository _presidenteRepository;
        private readonly DiputadoRepository _diputadoRepository;
        private readonly AlcaldesRepository _alcaldesRepository;
        //private readonly MunicipioRepository _municipioRepository;
        //private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly VotoRepository _votoRepository;


        public VotacionesServices(PresidenteRepository presidenteRepository, VotoRepository votoRepository, AlcaldesRepository alcaldesRepository, DiputadoRepository diputadoRepository/*, MunicipioRepository municipioRepository, EstadoCivilRepository estadoCivilRepository*/)
        {
            _presidenteRepository = presidenteRepository;
            //    _municipioRepository = municipioRepository;
            //   _estadoCivilRepository = estadoCivilRepository;
            _votoRepository = votoRepository;
            _alcaldesRepository = alcaldesRepository;

            _diputadoRepository = diputadoRepository;
        }

        #region Diputados
        public ServiceResult ListDip()
        {
            var result = new ServiceResult();
            try
            {
                var list = _diputadoRepository.List();

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion
        #region Alcaldes
        public ServiceResult ListAlc(string DNI)
        {
            var result = new ServiceResult();
            try
            {
                var list = _alcaldesRepository.ListA(DNI);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        #endregion
        #region Presidentes

        public ServiceResult ListadoPresi()
        {
            var result = new ServiceResult();
            try
            {
                var list = _presidenteRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Voto
        public ServiceResult InsertarVoto(tbVotos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _votoRepository.Insert(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarVotoD( int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _votoRepository.InsertD(id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
