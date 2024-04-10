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
    }
}
