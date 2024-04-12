using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class MesaService
    {
        private readonly API _api;

        public MesaService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerMesaList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MesaViewModel>, IEnumerable<MesaViewModel>>(req =>
                {
                    req.Path = $"API/Mesa/List";
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

        public async Task<ServiceResult> CrearMesa(MesaViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<MesaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Mesa/Create";
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

        public async Task<ServiceResult> ObtenerMesa()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MesaViewModel>, IEnumerable<MesaViewModel>>(req =>
                {
                    req.Path = $"API/Mesa/Fill/01";

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
        public async Task<ServiceResult> ObtenerMesaMindy(int Mes_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<MesaViewModel>, MesaViewModel>(req =>
                {
                    req.Path = $"API/Mesa/Fill/{Mes_Id}";
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

        public async Task<ServiceResult> EditarMesa(MesaViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<MesaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Mesa/Edit";
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






        public async Task<ServiceResult> EliminarMesa(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Mesa/Delete?EsC_Id={id}";
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
        public async Task<ServiceResult> DetallesMesa(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<MesaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Mesa/DetailsMesas?Esta_Id={id}";
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
