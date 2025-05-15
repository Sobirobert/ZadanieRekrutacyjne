﻿
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ZadanieRekrutacyjne.Installers;

public class SwaggerInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZadanieRekrutacyjne", Version = "v1" });
            //c.ExampleFilters();

            //var securityScheme = new OpenApiSecurityScheme
            //{
            //    Name = "JWT Authentication",
            //    Description = "Enter JWT Bearer token",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.Http,
            //    Scheme = "bearer",
            //    BearerFormat = "JWT",
            //    Reference = new OpenApiReference
            //    {
            //        //Id = JwtBearerDefaults.AuthenticationScheme,
            //        Type = ReferenceType.SecurityScheme
            //    }
            //};
            //c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            //c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {securityScheme, new string[] {}}
            //});

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath);
        });

        //services.AddSwaggerExamplesFromAssemblyOf<Program>();
    }
}
