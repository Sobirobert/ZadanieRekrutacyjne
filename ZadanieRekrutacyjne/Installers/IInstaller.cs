namespace ZadanieRekrutacyjne.Installers;
public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration Configuration);
}