using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using multitenant.Application.Contracts.Inventario;
using multitenant.Application.DTO.Inventario;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.WebApi.Inventario
{

    [Authorize]
    [Route("{slugTenant}/api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Fields
        private readonly IProductoAppService _ProductoAppService;
        #endregion Fields

        #region Const
        #endregion Const

        #region builder
        public ProductoController(IProductoAppService ProductoAppService)
        {
            _ProductoAppService = ProductoAppService;
        }
        #endregion builder

        #region Method
        /// <summary>
        /// Consultar producto por slugtenant
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        [Route(nameof(ProductoController.GetProducto))]
        public RequestResult<List<ProductoDTO>> GetProducto()
        {
            var slugTenant = HttpContext.Items["SlugTenant"];
            string slugTenantVal = slugTenant != null ? slugTenant.ToString() : string.Empty;

            return _ProductoAppService.GetProducto(slugTenantVal);

        }

        /// <summary>
        /// Guardar Poducto
        /// </summary>
        /// <param name="productoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(ProductoController.SaveProducto))]
        public RequestResult<string> SaveProducto(ProductoDTO productoDTO)
        {
            return _ProductoAppService.SaveProducto(productoDTO);

        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(ProductoController.DeleteProducto))]
        public RequestResult<bool> DeleteProducto(string idProducto)
        {

            return _ProductoAppService.DeleteProducto(idProducto);

        }


        #endregion Method

    }
}
