// A partir da versão 5.0, o EF Core trouxe diversas novidades em relação às suas versões anteriores. Os principais pontos atualizados são:
//
// 1. Relacionamentos muitos para muitos não necessitam de declaração explícita da tabela de junção.
// 2. Consultas LINQ podem ser divididas em diversas consultas SQL, inclusive coleções relacionadas.
// 3. Sistema mais simples e prático de log através do novo método LogTo().
// 4. Inclusões filtradas agora podem ser realizadas.
//
// Novidades no EF Core 5.0
// Artigo - 04/05/2022 - 13 minutos para o fim da leitura
// https://docs.microsoft.com/pt-br/ef/core/what-is-new/ef-core-5.0/whatsnew

using WebAPIMinimo.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPIMinimo.Data;

public class DataContext : DbContext
{
    public DbSet<Produto> Produto { get; set; }

    /// <summary>
    /// Para NÃO precisar disparar manualmente o comando "Add-Migration NomeDaTabela" 
    /// coloquei a cláusula "=> Database.EnsureCreated()" que verifica se já existe o
    /// Banco de Dados, se NÃO existir cria automaticamente.
    /// </summary>
    /// <param name="options"></param>
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    => Database.EnsureCreated();
}
