namespace WebAPIMinimo.Data.DTOs;

/// <summary>
/// Create Data Transfer Objects (DTOs)
/// Article - 05/09/2022 - 2 minutes to read
/// https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
/// 
/// - Com DTO podemos retornar parâmetros "calculados" em tempo de execução para o nosso usuário, 
/// ou seja, informações que não estão armazenadas.
/// - Com DTO podemos definir os parâmetros enviados de maneira isolada do nosso modelo do banco de dados.
/// 
/// Pendência - Não consegui fazer com tipo CHAR:
/// public char? Tipo { get; set; }
/// </summary>
public class ReadDataContextDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal? Preco { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime MomentoDaConsulta { get; set; }
}
