using Dtos.Base;
using Entidades.Base;

namespace BindDominoDto.Base
{
    public interface IAutoMapeamento<TDto, TDominio>
        where TDto : IDto
        where TDominio : IEntidade
    {
        TDominio Mapeamento(TDto model);

        TDto Mapeamento(TDominio dominio);
    }
}