namespace WebAPIMinimo.Model;

/// <summary>
/// Classe modelo do Poduto.
/// 
/// Não consegui trabalhar com o tipo CHAR
/// public char? Tipo { get; set; }
/// </summary>
public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal? Preco { get; set; }
    public DateTime? DataFabricacao { get; set; }
}