using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class UsuarioService
    {
        private readonly API _api;

        public UsuarioService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> UsuarioList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Usuario/List";
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




        public async Task<ServiceResult> Login(string Usuario, string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Usuario/LoginHome?Usuario={Usuario}&Contra={Contra}";
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

        public async Task<ServiceResult> ValidarUsuario(string Usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Home/ValidarUsuarioHome?Usuario={Usuario}";
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

        public async Task<ServiceResult> ValidarClave(string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Home/ValidarClaveHome?Contra={Contra}";
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







        public async Task<ServiceResult> CrearUsuario(UsuarioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/Create";
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

        public async Task<ServiceResult> ObtenerUsuario()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Usuario/Fill/01";

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
        public async Task<ServiceResult> ObtenerUsuarioMindy(int Usuar_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<UsuarioViewModel>, UsuarioViewModel>(req =>
                {
                    req.Path = $"API/Usuario/Fill/{Usuar_Id}";
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

        public async Task<ServiceResult> EditarUsuario(UsuarioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/Edit";
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









        public async Task<ServiceResult> EditarUsuarioC(UsuarioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/EditC";
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






        public async Task<ServiceResult> EliminarUsuario(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/Delete?Usuar_Id={id}";
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
        public async Task<ServiceResult> DetallesUsuario(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/DetailsUsuarios?Usuar_Id={id}";
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
