using ZadanieRekrutacyjne.Models;
using ZadanieRekrutacyjne.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new StorageConfig("",""));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.Run();
