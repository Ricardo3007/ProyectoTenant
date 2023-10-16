
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using multitenant.Application.Admin;
using multitenant.Application.Contracts.Admin;
using multitenant.Application.Contracts.Generics;
using multitenant.Application.Contracts.Inventario;
using multitenant.Application.Generics;
using multitenant.Application.Inventario;
using multitenant.Domain.Contracts.Admin;
using multitenant.Domain.Contracts.Inventario;
using multitenant.Infrastructure.Admin;
using multitenant.Infrastructure.DataAccess.MultAdminContext;
using multitenant.Infrastructure.DataAccess.MultInventario;
using multitenant.Infrastructure.Inventario;
using multitenant.WebApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<MultAdminContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionStringNombre1"]));
builder.Services.AddDbContext<MultInventarioContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionStringNombre2"]));


//Configurar autenticación basada en JWT
var key = Encoding.UTF8.GetBytes("(4j0Id?6~9:jq40`Hb2U");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:4200",
            ValidAudience = "https://localhost:4200",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

#region application
builder.Services.AddTransient<IOrganizationsAppService, OrganizationsAppService>();
builder.Services.AddTransient<IUsersAppService, UsersAppService>();
builder.Services.AddTransient<IJwtAppService, JwtAppService>();
builder.Services.AddTransient<IProductoAppService, ProductoAppService>();
#endregion application

#region domain
builder.Services.AddTransient<IOrganizationsDomainService, OrganizationsDomainService>();
builder.Services.AddTransient<IUsersDomainService, UsersDomainService>();
builder.Services.AddTransient<IProductoDomainService, ProductoDomainService>();
#endregion domain

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MultitenantMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

