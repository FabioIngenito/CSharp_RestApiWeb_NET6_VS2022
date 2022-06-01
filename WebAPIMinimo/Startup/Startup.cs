//EXPLICAÇÃO:

//Não existe o startup.cs no visual studio 2022
//02/02/2022
//https://cursos.alura.com.br/forum/topico-nao-existe-o-startup-cs-no-visual-studio-2022-199814
//
//#Novidades #AspNet6 #Startup
//ASP.NET 6 - O QUE ACONTECEU COM A CLASSE STARTUP?
//8 de dez. de 2021
//desenvolvedor.io
//https://youtu.be/VgjHQvprRy0
//
//Configuração no ASP.NET Core
//Artigo - 12/05/2022
//75 minutos para o fim da leitura
//https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0

using WebAPIMinimo.Data;
using Microsoft.EntityFrameworkCore;
using WebAPIMinimo.Model;

namespace WebAPIMinimo.Startup;

internal class Startup : IStartup
{
    #region Propriedades
    public IConfiguration Configuration { get; }
    #endregion

    #region Construtores
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    #endregion

    #region Métodos
    /// <summary>
    /// Add services to the container.
    /// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public void ConfigureServices(IServiceCollection services)
    {
        //Serviço de Banco de Dados
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebAPIMinimoConnectionMSSQLLocalDB"));
            //options.UseSqlServer(Configuration.GetConnectionString("WebAPIMinimoConnectionMSSQLSERVER2019"));
            //options.UseMySQL(Configuration.GetConnectionString("WebAPIMinimoConnectionMySQL"));
        });

        //Serviço Automapper inicializado:
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <summary>
    /// Configure the HTTP request pipeline.
    /// O WebApplicationBuilder substitui o IApplicationBuilder
    /// </summary>
    /// <param name="app">WebApplication</param>
    /// <param name="environment">IWebHostEnvironment</param>
    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            //É possível trabalhar FORA do Controller se quiser.
            //Precisa ficar entre o "UseSwagger();" e "UseSwaggerUI();"
            //Descomente a linha "Mapeamento(app);" e veja:
            //Mapeamento(app);

            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }

    /// <summary>
    /// Isolei este quase CRUD (falta o Update) montado aqui.
    /// O mais correto é criar um Controller para gerenciar o POST.
    /// O interessante é que NÃO está usando o Mapper, pois nem precisa.
    /// 
    /// * IMPORTANTE: Para adicionar um produto NÃO digite o "ID" no caso do 
    /// Microsoft SQL Server, pode dar conflito no identity.
    /// </summary>
    /// <param name="app">Recebe uma WebApplication</param>
    private static void Mapeamento(WebApplication app)
    {
        app.MapPost("AdicionaProduto", async (Produto produto, DataContext contexto) =>
        {
            contexto.Produto.Add(produto);
            await contexto.SaveChangesAsync();
        });

        app.MapGet("ListarProdutos", async (DataContext contexto) =>
        {
            return await contexto.Produto.ToListAsync();
        });

        app.MapGet("ObterProduto/{id}", async (int id, DataContext contexto) =>
        {
            return await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);
        });

        app.MapDelete("ExcluirProduto/{id}", async (int id, DataContext contexto) =>
        {
            Produto? produtoExcluir = await contexto.Produto.FirstOrDefaultAsync(p => p.Id == id);

            if (produtoExcluir != null)
            {
                contexto.Produto.Remove(produtoExcluir);
                await contexto.SaveChangesAsync();
            }
        });
    }

    #endregion
}