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
   

        public PartidoService(API api/*, BlobStorage blobStorage*/)
        {
            _api = api;
            //_blobStorage = blobStorage;
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

        public async Task<ServiceResult> CrearPartido(PartidosViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<PartidosViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Partido/Create";
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

        //public async Task<ServiceResult> SubirImagen(string localFilePath)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var response = await _blobStorage.SubirImagen(localFilePath);
        //        var statusCode = response.GetRawResponse().Status;
        //        if (statusCode != 201)
        //        {
        //            return result.Error("Error, no se pudo guardar la imagen");
        //        }
        //        else
        //        {
        //            return result.Ok("Imagen guardada", _blobStorage.ObtenerUrlImagen(localFilePath));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(Helpers.GetMessage(ex));
        //        throw;
        //    }
        //}

    }
}
