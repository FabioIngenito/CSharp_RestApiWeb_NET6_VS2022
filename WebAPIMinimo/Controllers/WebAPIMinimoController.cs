using WebAPIMinimo.Data;
using WebAPIMinimo.Data.DTOs;
using WebAPIMinimo.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMinimo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebAPIMinimoController : ControllerBase
{
    #region Variáveis
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    #endregion

    #region Construtores

    /// <summary>
    /// Este construtor irá inicializar a variável "_context"
    /// </summary>
    /// <param name="context">DataContext</param>
    /// <param name="mapper">Pacote AutoMapper</param>
    public WebAPIMinimoController(DataContext context, IMapper mapper)
    {
        _context = context;
        //Iniciar o Automapper:
        _mapper = mapper;
    }

    #endregion

    /// <summary>
    /// Adionar um produto
    /// Padrão Arquitetural REST: [HttpPost]
    /// 
    /// O DTO limita o que deve ser efetivamente envioado na requisição, pois a
    /// responsabilidade de criar a chave ID é do Banco de Dados. Mandamos então
    /// somente o nome.
    ///
    /// Não consegui passar o tipo CHAR:
    /// Tipo = produtoDTO.Tipo,
    /// </summary>
    /// <param name="produto">O próprio produto (Dados do Produto)</param>
    /// <returns>ID em IActionResult</returns>
    [HttpPost]
    public IActionResult AdicionaProduto([FromBody] CreateDataContextDTO produtoDTO)
    {
        //Converter o produtoDTO em um produto (inicializar as propriedades):
        //Converter produtoDTO em produto no braço (sem usar o AutoMapper):
        //Produto produto = new()
        //{
        //    Nome = produtoDTO.Nome,
        //    Preco = produtoDTO.Preco,
        //    DataFabricacao = produtoDTO.DataFabricacao
        //};

        //Converter produtoDTO em produto usando o MAPPER:
        Produto produto = _mapper.Map<Produto>(produtoDTO);

        //Adicionamos o objeto mapeado no Banco de Dados:
        _context.Produto.Add(produto);
        //SALVA as informações no Banco de Dados:
        _context.SaveChanges();

        // 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema.
        // Além de informarmos que o recurso foi criado, é importante informarmos onde podemos localizá-lo.
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { produto.Id }, produto);
    }

    /// <summary>
    /// Recupera Todos os Produtos
    /// </summary>
    /// <returns>Retonar como "IEnumerable". Poderia retornar "IActionResult".</returns>
    [HttpGet]
    public IEnumerable<Produto> RecuperaProdutos()
    {
        return _context.Produto;
    }

    /// <summary>
    /// Recupera o Produto pelo ID 
    /// ENVIAR PARÂMETRO: [HttpGet("{param}")]
    /// 
    /// DTO -> Neste caso sabemos o momento exato da consulta, mas esta informação NÃO
    /// será armazenada no Banco de Dados.
    /// 
    /// Não consegui passar o tipo CHAR:
    /// Tipo = produto.Tipo,
    /// </summary>
    /// <param name="id">Identificador do Produto</param>
    /// <returns>Dados do Produto como um IActionResult</returns>
    [HttpGet("passaPorId/{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        Produto? produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);

        if (produto != null)
        {
            //Converter produto em produtoDTO usando o MAPPER:
            ReadDataContextDTO produtoDTO = _mapper.Map<ReadDataContextDTO>(produto);

            //Este campo precisa ser configurado por fora do AutoMapper pois NÂO pertence a classe.
            produtoDTO.MomentoDaConsulta = DateTime.Now;

            return Ok(produtoDTO);
        } 

        return NotFound();
    }

    /// <summary>
    /// * CRIANDO DUAS "GETS" SIMILARES:
    /// 
    /// Caso NÃO seja definido um roteamento específico para uma Action (exemplo: 
    /// "passaPorId1"), esta estará utilizando o roteamento padrão da controller. 
    /// Acontece isso com o GET e POST que são chamados por "/produtos", o que os
    /// diferencia são os métodos HTTP, portanto NÃO ocorre um conflito.
    /// 
    /// Quando definimos um roteamento específico, a controller faz uma composição do seu 
    /// valor específico com o roteamento padrão.
    ///
    /// O exemplo está usando uma rota composta, sendo chamada por "produtos/id", sendo 
    /// id um valor inteiro. Como os dois métodos HTTP são iguais, ocorrerá um conflito
    /// porque eles apontam o mesmo endereçamento. Deverá ser criada uma rota diferente 
    /// em uma das actions para o conflito deixar de existir. 
    /// 
    /// Exemplos de rotas diferentes:
    /// - [HttpGet("passaPorId/{id}")]: rota final - produtos/passaPorId/1
    /// - [HttpGet("passaPorId1/{id1}")]: rota final - produtos/passaPorId1/1
    /// 
    /// Em síntese, as chaves '{}' representam variáveis, o nome que definimos dentro dela 
    /// NÃO é relevante para o roteamento, somente o seu tipo.
    /// </summary>
    /// <param name="id1">Identificador do Produto</param>
    /// <returns>Dados do Produto como um IActionResult</returns>
    [HttpGet("passaPorId1/{id1}")]
    public IActionResult RecuperaProdutoPorId1(int id1)
    {
        Produto? produto = _context.Produto.FirstOrDefault(produto => produto.Id == id1);

        if (produto != null)
        {
            //Converter produto em produtoDTO no braço (SEM usar o AutoMapper):
            ReadDataContextDTO produtoDTO = new()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                DataFabricacao = produto.DataFabricacao,
                MomentoDaConsulta = DateTime.Now
            };

            return Ok(produtoDTO);
        }

        return NotFound();
    }

    /// <summary>
    /// HTTP PUT - Atualizar
    /// [FromBody] - Corpo da requisição
    /// Boas práticas manda retornar um "204" (no content)
    /// 
    /// Não consegui passar o tipo CHAR:
    /// produto.Tipo = produtoNovoDTO.Tipo;
    /// </summary>
    /// <returns>No caso de PUT, boa prática: Retorne "NoContent();"</returns>
    [HttpPut("{id}")]
    public IActionResult AtualizaProduto(int id, [FromBody] UpdateDataContextDTO produtoNovoDTO)
    {
        Produto? produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);

        if (produto == null) return NotFound();

        //Converter produtoNovoDTO em produto no braço (sem usar o AutoMapper):
        //DTO -> Veja que eu NÃO preciso do "ID".
        //produto.Nome = produtoNovoDTO.Nome;
        //produto.Preco = produtoNovoDTO.Preco;
        //produto.DataFabricacao = produtoNovoDTO.DataFabricacao; 

        //Converter produtoNovoDTO em produto usando o MAPPER:
        _mapper.Map(produtoNovoDTO, produto);

        _context.SaveChanges();

        return NoContent();
    }

    /// <summary>
    /// HTTP Delete - Apagar
    /// Boas práticas manda retornar um "204" (no content)
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No caso de DELETE, boa prática: Retorne "NoContent();</returns>
    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        Produto? produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);

        if (produto == null) return NotFound();

        _context.Remove(produto);
        _context.SaveChanges();

        return NoContent();
    }
}
