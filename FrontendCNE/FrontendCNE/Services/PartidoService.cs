using CNE.Common.Models;
using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class PartidoService
    {
        private readonly API _api;

        public PartidoService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> PartidoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PartidosViewModel>, IEnumerable<PartidosViewModel>>(req =>
                {
                    req.Path = $"API/Partido/List";
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
