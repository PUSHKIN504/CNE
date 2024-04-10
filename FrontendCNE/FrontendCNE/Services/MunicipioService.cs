using CNE.Common.Models;

using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class MunicipioService
    {



        private readonly API _api;

        public MunicipioService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> MunicipioList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, IEnumerable<MunicipioViewModel>>(req =>
                {
                    req.Path = $"API/Municipio/List";
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

        public async Task<ServiceResult> CrearMunucipio(MunicipioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<MunicipioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/Create";
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

        public async Task<ServiceResult> ObtenerMunicipio()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, IEnumerable<MunicipioViewModel>>(req =>
                {
                    req.Path = $"API/Municipio/Fill/01";

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
        public async Task<ServiceResult> ObtenerMunicipio(string Mun_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<MunicipioViewModel>, MunicipioViewModel>(req =>
                {
                    req.Path = $"API/Municipio/Fill/{Mun_Id}";
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

        public async Task<ServiceResult> EditarMunicipio(MunicipioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<MunicipioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/Edit";
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




        public async Task<ServiceResult> ObtenerMunicipioMindy(string Mun_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<MunicipioViewModel>, MunicipioViewModel>(req =>
                {
                    req.Path = $"API/Municipio/Fill/{Mun_Id}";
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

        public async Task<ServiceResult> EliminarMunicpio(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/Delete?Mun_Id={id}";
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
        public async Task<ServiceResult> DetallesMunicipio(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, MunicipioViewModel>(req =>
                {
                    req.Path = $"API/EstadoCivil/Fill/{id}";
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
