using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using multitenant.Application.Admin;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.Contracts.Generics;
using multitenant.Application.Contracts.Inventario;
using multitenant.Application.DTO.Admin;
using multitenant.Application.DTO.Inventario;
using multitenant.Domain.Contracts.Inventario;
using multitenant.Domain.Entities.MultInventario;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Inventario
{
    public class ProductoAppService: IProductoAppService
    {
        private readonly IProductoDomainService _ProductoDomainService;
        private readonly IMapper _Mapper;
        private readonly IOrganizationsAppService _OrganizationsAppService;

        public ProductoAppService(IProductoDomainService ProductoDomainService, IOrganizationsAppService OrganizationsAppService, IMapper Mapper)
        {
            _ProductoDomainService = ProductoDomainService;
            _Mapper = Mapper;
            _OrganizationsAppService = OrganizationsAppService;

        }

        #region Method
        public RequestResult<List<ProductoDTO>> GetProducto(string slugTenant)
        {
            try
            {


                if (slugTenant == null)
                {
                    return RequestResult<List<ProductoDTO>>.CreateUnsuccessful(new string[] { "El tenant no puede venir vacio, por favor revisar path." });
                }


                OrganizationsDTO? varOrganization = _OrganizationsAppService.GetOrganizationbytenant(slugTenant);

                if(varOrganization == null)
                {
                    return RequestResult<List<ProductoDTO>>.CreateUnsuccessful(new string[] { "No se encuentra relacion con el tenant enviado." });
                }

                var resultProducts = _ProductoDomainService.GetProducto(varOrganization.IdDTO);
                List<ProductoDTO> productsMap = _Mapper.Map<List<Products>, List<ProductoDTO>>(resultProducts);

                return RequestResult<List<ProductoDTO>>.CreateSuccessful(productsMap);
            }
            catch (Exception ex)
            {
                return RequestResult<List<ProductoDTO>>.CreateError(ex.Message.ToString());
            }

        }


        public RequestResult<string> SaveProducto(ProductoDTO productoDTO)
        {
            try
            {
                Products tipoFiltro = _Mapper.Map<ProductoDTO, Products>(productoDTO);

                Products resultData = _ProductoDomainService.SaveProducto(tipoFiltro);
                if (resultData == null) return RequestResult<string>.CreateUnsuccessful(new string[] { "Error al Guardar Registro" });
                return RequestResult<string>.CreateSuccessful(resultData.Id.ToString());
            }
            catch (Exception ex)
            {
                return RequestResult<string>.CreateError(ex.Message.ToString());
            }
        }


        public RequestResult<bool> DeleteProducto(string idProducto)
        {
            try
            {


                if (idProducto.IsNullOrEmpty())
                {
                    return RequestResult<bool>.CreateUnsuccessful(new string[] { "El identificador del producto no puede esta vacio." });
                }


                bool resultTipoFiltro = _ProductoDomainService.DeleteProducto(Guid.Parse(idProducto));
                if (!resultTipoFiltro) return RequestResult<bool>.CreateUnsuccessful(new string[] { "Error al Eliminar Registro" });
                return RequestResult<bool>.CreateSuccessful(resultTipoFiltro);
            }
            catch (Exception ex)
            {
                return RequestResult<bool>.CreateError(ex.Message.ToString());
            }
        }

        #endregion Method
    }
}
