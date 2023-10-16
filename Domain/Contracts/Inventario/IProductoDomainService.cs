
using multitenant.Application.DTO.Inventario;
using multitenant.Domain.Entities.MultInventario;

namespace multitenant.Domain.Contracts.Inventario
{
    public interface IProductoDomainService
    {
        List<Products> GetProducto(Guid idOrganization);
        Products SaveProducto(Products products);
        bool DeleteProducto(Guid idProducto);

    }
}
