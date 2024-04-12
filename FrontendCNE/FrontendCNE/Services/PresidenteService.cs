using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class PresidenteService
    {
        private readonly API _api;

        public PresidenteService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> PresList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PresidenteVIewModel>, IEnumerable<PresidenteVIewModel>>(req =>
                {
                    req.Path = $"Presidentes/List";
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




        public async Task<ServiceResult> CrearPresidente(PresidenteVIewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<PresidenteVIewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Presidente/Create";
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

        public async Task<ServiceResult> ObtenerPresidente()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PresidenteVIewModel>, IEnumerable<PresidenteVIewModel>>(req =>
                {
                    req.Path = $"API/Presidente/Fill/01";

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
        public async Task<ServiceResult> ObtenerPresidenteMindy(int Dip_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<PresidenteVIewModel>, PresidenteVIewModel>(req =>
                {
                    req.Path = $"API/Presidente/Fill/{Dip_Id}";
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

        public async Task<ServiceResult> EditarPresidente(PresidenteVIewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<PresidenteVIewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Presidente/Edit";
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






        public async Task<ServiceResult> EliminarPresidente(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Presidente/Delete?Dip_Id={id}";
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
        public async Task<ServiceResult> DetallesPresidente(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<PresidenteVIewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Presidente/DetailsPresidente?Dip_Id={id}";
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
