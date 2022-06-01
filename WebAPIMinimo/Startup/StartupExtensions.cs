namespace WebAPIMinimo.Startup;

internal static class StartupExtensions
{
    /// <summary>
    /// Extensão da Startup.
    /// Aqui você pode gerenciar o Enviroment para onde o sistema apontará.
    /// O WebApplicationBuilder substitui o IApplicationBuilder.
    /// </summary>
    /// <typeparam name="TStartup">UseStartup<TStartup> do tipo IStartup</typeparam>
    /// <param name="WebAppBuilder">WebApplicationBuilder</param>
    /// <returns>WebAppBuilder</returns>
    /// <exception cref="ArgumentException">"Classe Startup inválida"</exception>
    internal static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
    {
        //Caso retorne nulo gera uma exceção. Usa "Reflexion" somente uma vez.
        if (Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) is not IStartup startup) 
            throw new ArgumentException("Classe Startup.cs inválida");

        startup.ConfigureServices(WebAppBuilder.Services);

        WebApplication? app = WebAppBuilder.Build();
        startup.Configure(app, app.Environment);

        app.Run();

        return WebAppBuilder;
    }
}
