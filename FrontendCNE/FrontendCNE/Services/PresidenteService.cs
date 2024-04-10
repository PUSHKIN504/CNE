using FrontendCNE.Models;
using FrontendCNE.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendCNE.Services
{
    public class PresidenteService
    {
        private readonly API _api;

        public PresidenteService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> PresList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PresidenteVIewModel>, IEnumerable<PresidenteVIewModel>>(req =>
                {
                    req.Path = $"Presidentes/List";
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
