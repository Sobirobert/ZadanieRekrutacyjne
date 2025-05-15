using Domain.Entities;
using Microsoft.Extensions.Logging;
using ZadanieRekrutacyjne.Installers;
using ZadanieRekrutacyjne.Patterns.Configuratin;
using ZadanieRekrutacyjne.Patterns.FactoryPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.InstallServicesInAssembly(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new StorageConfig("",""));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
        c.EnableAnnotations();

    });
}

app.UseHttpsRedirection();

app.MapGet("/{id}",async (Guid id) =>
{
    var config = app.Services.GetService<StorageConfig>();
    var storage = Factory.Create(config);
    return await storage.Get<Person>(id);
});
//app.UseAuthorization();

app.MapControllers();
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    throw new Exception("Something is wrong with application. Please check Program files.");
}

