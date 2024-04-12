using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FrontendCNE.Services
{
    public class EstadoCivilServices
    {
        private readonly API _api;

        public EstadoCivilServices(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerEstadoCivilList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, IEnumerable<EstadoCivilViewModel>>(req =>
                {
                    req.Path = $"API/EstadoCivil/List";
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

        public async Task<ServiceResult> CrearEstadoCivil(EstadoCivilViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/Create";
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

        public async Task<ServiceResult> ObtenerEstadoCivil()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, IEnumerable<EstadoCivilViewModel>>(req =>
                {
                    req.Path = $"API/EstadoCivil/Fill/01";

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
        public async Task<ServiceResult> ObtenerEstadoCivilMindy(int EsC_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, EstadoCivilViewModel>(req =>
                {
                    req.Path = $"API/EstadoCivil/Fill/{EsC_Id}";
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

        public async Task<ServiceResult> EditarEstadoCivil(EstadoCivilViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/Edit";
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




  

        public async Task<ServiceResult> EliminarEstadoCivil(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/Delete?EsC_Id={id}";
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
        public async Task<ServiceResult> DetallesEstadoCivil(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/DetailsEstadoCivils?EsC_Id={id}";
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
