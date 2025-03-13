using Aplication.AutoMapperProfiles;
using Aplication.Services;
using Aplication.Services.Impl;
using Common.Services;
using Common.Services.Impl;

using Microsoft.OpenApi.Models;
// using Aplication.Services;   // Ajusta según tu ruta real
// using Common.Proxy;          // Ajusta según tu ruta real
// using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar controladores
builder.Services.AddControllers();

// 2. Registrar Swagger (versión estándar con Swashbuckle)
object value = builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// 3. Registrar AutoMapper (si tus perfiles están en este ensamblado, usa typeof(Program).Assembly)
builder.Services.AddAutoMapper(typeof(CountryProfile));

// 4. Registrar Proxy y Service
builder.Services.AddHttpClient<ICountryProxy, CountryProxy>();
builder.Services.AddTransient<ICountryService, CountryService>();

var app = builder.Build();

// 5. Sólo habilitar Swagger en modo development (o en todos, si lo prefieres)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Genera el JSON
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        // c.RoutePrefix = string.Empty; // si quieres servir la UI en la raíz
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();