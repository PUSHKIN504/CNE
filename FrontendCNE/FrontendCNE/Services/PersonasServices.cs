using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class PersonasServices
    {
        private readonly API _api;

        public PersonasServices(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerPersonasList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PersonasViewModel>, IEnumerable<PersonasViewModel>>(req =>
                {
                    req.Path = $"API/Persona/List";
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

        public async Task<ServiceResult> CrearPersona(PersonasViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<PersonasViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/Create";
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

        public async Task<ServiceResult> ObtenerPersona()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PersonasViewModel>, IEnumerable<PersonasViewModel>>(req =>
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
        public async Task<ServiceResult> ObtenerPersonaMindy(int Per_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<PersonasViewModel>, PersonasViewModel>(req =>
                {
                    req.Path = $"API/Persona/Fill/{Per_Id}";
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

        public async Task<ServiceResult> EditarPersona(PersonasViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<PersonasViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/Edit";
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






        public async Task<ServiceResult> EliminarPersona(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/Delete?Per_Id={id}";
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
                var response = await _api.Get<PersonasViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EliminarPersona/DetailsPersona?Esta_Id={id}";
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
