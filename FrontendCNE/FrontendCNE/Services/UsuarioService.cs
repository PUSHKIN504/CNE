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

    }
}
