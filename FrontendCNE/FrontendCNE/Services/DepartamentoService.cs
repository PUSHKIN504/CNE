using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class DepartamentoService
    {
        private readonly API _api;

        public DepartamentoService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerDepartamentoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, IEnumerable<DepartamentoViewModel>>(req =>
                {
                    req.Path = $"API/Departamento/List";
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

        public async Task<ServiceResult> CrearDepartamento(DepartamentoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/Create";
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

        public async Task<ServiceResult> ObtenerDepartamento()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, IEnumerable<DepartamentoViewModel>>(req =>
                {
                    req.Path = $"API/Departamento/Fill/01";

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
        public async Task<ServiceResult> ObtenerDepartamentoMindy(string Dep_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, DepartamentoViewModel>(req =>
                {
                    req.Path = $"API/Departamento/Fill/{Dep_Id}";
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

        public async Task<ServiceResult> EditarDepartamento(DepartamentoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/Edit";
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

        public async Task<ServiceResult> DepartamentoCiudadesList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, IEnumerable<DepartamentoViewModel>>(req =>
                {
                    req.Path = $"API/Departamento/ListadoDepartamentosCiudades";
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
        public async Task<ServiceResult> EliminarDepartamento(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/Delete?Dep_Id={id}";
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
        public async Task<ServiceResult> DetallesDepartamento(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/DetailsDepartamentos?Esta_Id={id}";
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
