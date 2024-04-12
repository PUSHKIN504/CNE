using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class AlcaldeService
    {
        private readonly API _api;

        public AlcaldeService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> AlcaldeList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<AlcaldeViewModel>, IEnumerable<AlcaldeViewModel>>(req =>
                {
                    req.Path = $"API/Alcalde/List";
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









        public async Task<ServiceResult> CrearAlcalde(AlcaldeViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<AlcaldeViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Alcalde/Create";
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

        public async Task<ServiceResult> ObtenerAlcalde()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<AlcaldeViewModel>, IEnumerable<AlcaldeViewModel>>(req =>
                {
                    req.Path = $"API/Alcalde/Fill/01";

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
        public async Task<ServiceResult> ObtenerAlcaldeMindy(int Alc_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<AlcaldeViewModel>, AlcaldeViewModel>(req =>
                {
                    req.Path = $"API/Alcalde/Fill/{Alc_Id}";
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

        public async Task<ServiceResult> EditarAlcalde(AlcaldeViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<AlcaldeViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Alcalde/Edit";
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






        public async Task<ServiceResult> EliminarAlcalde(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Alcalde/Delete?Alc_id={id}";
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
        public async Task<ServiceResult> DetallesAlcalde(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<AlcaldeViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Alcalde/DetailsAlcaldes?Alc_id={id}";
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
