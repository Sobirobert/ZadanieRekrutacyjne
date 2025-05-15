using Application;
using Infrastructure;

namespace ZadanieRekrutacyjne.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddApplication();
        services.AddInfrastructure();
        services.AddControllers();
        //.AddFluentValidation(options =>
        //{
        //    options.RegisterValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
        //})
        //.AddJsonOptions(options =>
        //{
        //    options.JsonSerializerOptions.WriteIndented = true;
        //})
        //.AddXmlSerializerFormatters();
        // services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddMemoryCache();
        //services.AddAuthorization();
        //services.AddTransient<UserResolverService>();
        //services.AddScoped<ErrorHandlingMiddelware>();
        services.AddRazorPages();
        //services.AddMediatR(typeof(MvcInstaller));
        //services.AddApiVersioning(x =>
        //{
        //    x.DefaultApiVersion = new ApiVersion(1, 0);
        //    x.AssumeDefaultVersionWhenUnspecified = true;
        //    x.ReportApiVersions = true;
        //    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
        //});
    }
}
