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

        private readonly VotoRepository _votoRepository;
        private readonly CentroVotacionRepository _centroVotacionRepository;
        private readonly MesaRepository _mesaRepository;
        private readonly AlcaldeRepository _alcaldeRepository;
        private readonly DiputadoRepository _diputadoRepository; 
        private readonly AlcaldesRepository _alcaldesRepository;
        private readonly PartidoRepository _partidoRepository;






        public VotacionesServices(PresidenteRepository presidenteRepository, MesaRepository mesaRepository, VotoRepository votoRepository, AlcaldesRepository alcaldesRepository, CentroVotacionRepository centroVotacionRepository, AlcaldeRepository alcaldeRepository, DiputadoRepository diputadoRepository, PartidoRepository partidoRepository)
        {
            _presidenteRepository = presidenteRepository;
            _diputadoRepository = diputadoRepository;
            _votoRepository = votoRepository;
            _centroVotacionRepository = centroVotacionRepository;
            _mesaRepository = mesaRepository;
            _alcaldeRepository = alcaldeRepository;
            _alcaldesRepository = alcaldesRepository;
            _partidoRepository = partidoRepository;
        }

        #region Presidentes

        
        #endregion

       



        #region CentroVotaciones

        public ServiceResult ListadoCentroVotacion()
        {
            var result = new ServiceResult();
            try
            {
                var list = _centroVotacionRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }





        public ServiceResult InsertarCentroVotacion(tbCentrosVotaciones item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _centroVotacionRepository.Insert(item);
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



        public ServiceResult ListCentroVotacion(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _centroVotacionRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServiceResult EditarCentroVotacion(tbCentrosVotaciones item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _centroVotacionRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"editado con éxito", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarCentroVotacion(int CeV_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _centroVotacionRepository.Delete(CeV_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        #endregion





        #region Mesas

        public ServiceResult ListadoMesas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _mesaRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }





        public ServiceResult InsertarMesa(tbMesas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _mesaRepository.Insert(item);
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



        public ServiceResult ListMesa(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _mesaRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }


        public ServiceResult EditarMesa(tbMesas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _mesaRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"editado con éxito", list);
                }
                else
                {
                    return result.Error("Y existe un registro con ese nombre");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServiceResult EliminarMesa(int Mes_Id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _mesaRepository.Delete(Mes_Id);
                if (list.CodeStatus > 0)
                {
                    return result.Ok($"La accion ha sido existosa", list);
                }
                else
                {
                    return result.Error("No se pudo realizar la accion");
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }



        #endregion



        #region Alcalde

        public ServiceResult ListadoAlcalde()
        {
            var result = new ServiceResult();
            try
            {
                var list = _alcaldeRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }







        #endregion




        #region Diputado

        public ServiceResult ListadoDiputado()
        {
            var result = new ServiceResult();
            try
            {
                var list = _diputadoRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }







        #endregion

        #region Partido

        public ServiceResult ListadoPartido()
        {
            var result = new ServiceResult();
            try
            {
                var list = _partidoRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }







        #endregion

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
