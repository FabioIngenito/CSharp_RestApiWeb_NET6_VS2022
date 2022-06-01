using AutoMapper;
using WebAPIMinimo.Model;
using WebAPIMinimo.Data.DTOs;

namespace WebAPIMinimo.ProfilesMapper;

/// <summary>
/// Esta pasta "ProfilesMapper" e esta classe "ProdutosProfile" guarda os 
/// PERFIS do Pacote AUTOMAPPER.
/// 
/// Veja mais em:
/// AutoMapper - A convention-based object-object mapper.
/// https://docs.automapper.org/en/stable/ 
/// </summary>
public class ProdutosProfile : Profile
{
    /// <summary>
    /// Construtor desta classe que mapeia "CreateMap" os caminhos que serão construidos.
    /// </summary>
    public ProdutosProfile()
    {
        CreateMap<CreateDataContextDTO, Produto>();
        CreateMap<Produto, ReadDataContextDTO>();
        CreateMap<UpdateDataContextDTO, Produto>();
    }
}
