using CNE.Common.Models;
using FrontendCNE.Clases;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class RolService
    {
        private readonly API _api;

        public RolService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> RolList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<RolViewModel>, IEnumerable<RolViewModel>>(req =>
                {
                    req.Path = $"API/Rol/List";
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

        

        public async Task<ServiceResult> CrearRol(RolViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<RolViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/Create";
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




        public async Task<ServiceResult> CrearPantallaporRol([FromBody] FormData formData)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<FormData, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/Create";
                    req.Content = formData;
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









        public async Task<ServiceResult> PantallaList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PantallaViewModel>, IEnumerable<PantallaViewModel>>(req =>
                {
                    req.Path = $"API/Pantalla/List";
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







        public async Task<ServiceResult> RolesPantallaList(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PantallasPorRolViewModel>, IEnumerable<PantallasPorRolViewModel>>(req =>
                {
                    req.Path = $"API/Pantalla/List";
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



        public async Task<ServiceResult> EliminarRol(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/Delete?Roles_Id={id}";
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



    }
}
