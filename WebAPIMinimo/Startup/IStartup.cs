namespace WebAPIMinimo.Startup;

/// <summary>
/// Esta interface ajuda você criar outros "Startups" para redirecionar a outros ambientes.
/// </summary>
internal interface IStartup
{
    IConfiguration Configuration { get; }

    void Configure(WebApplication app, IWebHostEnvironment enviroment);

    void ConfigureServices(IServiceCollection services);
}
