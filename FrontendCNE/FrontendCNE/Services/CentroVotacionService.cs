using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class CentroVotacionService
    {

        private readonly API _api;

        public CentroVotacionService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerCentroVotacionList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<CentroVotacionesViewModels>, IEnumerable<CentroVotacionesViewModels>>(req =>
                {
                    req.Path = $"API/CentroVotacion/List";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> CrearCentroVotacion(CentroVotacionesViewModels item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<CentroVotacionesViewModels, ServiceResult>(req =>
                {
                    req.Path = $"API/CentroVotacion/Create";
                    req.Content = item;
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> ObtenerCentroVotacion()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<CentroVotacionesViewModels>, IEnumerable<CentroVotacionesViewModels>>(req =>
                {
                    req.Path = $"API/CentroVotacion/Fill/01";

                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }
        public async Task<ServiceResult> ObtenerCentroVotacionMindy(int CeV_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<CentroVotacionesViewModels>, CentroVotacionesViewModels>(req =>
                {
                    req.Path = $"API/CentroVotacion/Fill/{CeV_Id}";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> EditarCentroVotacion(CentroVotacionesViewModels item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<CentroVotacionesViewModels, ServiceResult>(req =>
                {
                    req.Path = $"API/CentroVotacion/Edit";
                    req.Content = item;
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }






        public async Task<ServiceResult> EliminarCentroVotacion(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/CentroVotacion/Delete?CeV_Id={id}";
                });

                if (response.Success)
                {
                    return result.Ok(response.Data);
                }
                else
                {
                    return result.FromApi(response);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
            }
        }
        public async Task<ServiceResult> DetallesCentroVotacion(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<CentroVotacionesViewModels, ServiceResult>(req =>
                {
                    req.Path = $"API/CentroVotacion/DetailsCentroVotacions?CeV_Id={id}";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }




    }
}
