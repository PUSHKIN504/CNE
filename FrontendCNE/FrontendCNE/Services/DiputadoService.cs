using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class DiputadoService
    {
        private readonly API _api;

        public DiputadoService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> DiputadoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DiputadoViewModel>, IEnumerable<DiputadoViewModel>>(req =>
                {
                    req.Path = $"API/Diputado/List";
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









        public async Task<ServiceResult> CrearDiputado(DiputadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<DiputadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Diputado/Create";
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

        public async Task<ServiceResult> ObtenerDiputado()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DiputadoViewModel>, IEnumerable<DiputadoViewModel>>(req =>
                {
                    req.Path = $"API/Diputado/Fill/01";

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
        public async Task<ServiceResult> ObtenerDiputadoMindy(int Dip_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<DiputadoViewModel>, DiputadoViewModel>(req =>
                {
                    req.Path = $"API/Diputado/Fill/{Dip_Id}";
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

        public async Task<ServiceResult> EditarDiputado(DiputadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<DiputadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Diputado/Edit";
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






        public async Task<ServiceResult> EliminarDiputado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Diputado/Delete?Dip_Id={id}";
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
        public async Task<ServiceResult> DetallesDiputado(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<DiputadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Diputado/DetailsDiputado?Dip_Id={id}";
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
