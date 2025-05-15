using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ZadanieRekrutacyjne.Installers;
public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ZadanieRekrutacyjneContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ZadanieRekrutacyjne")));
    }
}