
using multitenant.Domain.Contracts.Inventario;
using multitenant.Domain.Entities.MultInventario;
using multitenant.Infrastructure.DataAccess.MultInventario;

namespace multitenant.Infrastructure.Inventario
{
    public class ProductoDomainService: IProductoDomainService
    {
        private readonly MultInventarioContext _MultInventarioContext;
        public ProductoDomainService(MultInventarioContext MultInventarioContext)
        {
            _MultInventarioContext = MultInventarioContext;
        }

        public List<Products> GetProducto(Guid idOrganization)
        {
           return _MultInventarioContext.Products.Where(x => x.Estado == true && x.OrganizationId.Equals(idOrganization)).ToList();
        }

        public Products SaveProducto(Products products)
        {
            products.Id = Guid.NewGuid();
            //products.FechaReg = DateTime.Now;
            products.Estado = true;
            _MultInventarioContext.Products.Add(products);

            _MultInventarioContext.SaveChanges();
            return products;
        }

        public bool DeleteProducto(Guid idProducto)
        {
            Products rstaProducts = _MultInventarioContext.Products.Where(x => x.Id.Equals(idProducto)).FirstOrDefault();
            if (rstaProducts != null)
            {
                rstaProducts.Estado = false;

                _MultInventarioContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
