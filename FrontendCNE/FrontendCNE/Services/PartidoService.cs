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











        public async Task<ServiceResult> ObtenerPartido()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PartidosViewModel>, IEnumerable<PartidosViewModel>>(req =>
                {
                    req.Path = $"API/Partido/Fill/01";

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
        public async Task<ServiceResult> ObtenerPartidoMindy(int Par_Id)
        {
            var result = new ServiceResult();
            try
            {


                var response = await _api.Get<IEnumerable<PartidosViewModel>, PartidosViewModel>(req =>
                {
                    req.Path = $"API/Partido/Fill/{Par_Id}";
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

        public async Task<ServiceResult> EditarPartido(PartidosViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<PartidosViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Partido/Edit";
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






        public async Task<ServiceResult> EliminarPartido(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<string, ServiceResult>(req =>
                {
                    req.Path = $"API/Partido/Delete?Par_Id={id}";
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
        public async Task<ServiceResult> DetallesPartido(string id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<PartidosViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Partido/DetailsPartido?Par_Id={id}";
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
