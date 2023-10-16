using multitenant.Application.DTO.Inventario;
using OpheliaSuiteV2.Core.SSB.Lib.Models;

namespace multitenant.Application.Contracts.Inventario
{
    public interface IProductoAppService
    {
        RequestResult<List<ProductoDTO>> GetProducto(string slugTenant);

        RequestResult<string> SaveProducto(ProductoDTO productoDTO);

        RequestResult<bool> DeleteProducto(string idProducto);
    }
}
