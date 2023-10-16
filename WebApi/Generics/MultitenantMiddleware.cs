namespace multitenant.WebApi.Generics
{
    public class MultitenantMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public MultitenantMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var slugTenant = context.Request.Path.Value.Split('/')[1];

            // Obtener la cadena de conexión según el SlugTenant
            var connectionStringName = $"ConnectionStringNombre{slugTenant}";

            // Establecer la cadena de conexión en el contexto para su uso posterior
            context.Items["ConnectionString"] = _configuration.GetConnectionString(connectionStringName);

            await _next(context);
        }

    }
}
