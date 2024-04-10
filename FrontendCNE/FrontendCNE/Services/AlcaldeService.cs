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
    }
}
