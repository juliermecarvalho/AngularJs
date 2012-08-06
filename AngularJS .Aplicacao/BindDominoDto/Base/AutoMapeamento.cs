using AutoMapper;
using Dtos.Base;
using Entidades.Base;

namespace BindDominoDto.Base
{
    public abstract class AutoMapeamento<TDto, TDominio> : IAutoMapeamento<TDto, TDominio>
        where TDto : IDto
        where TDominio : IEntidade
    {
        public virtual TDominio Mapeamento(TDto model)
        {
            Mapper.CreateMap<TDto, TDominio>();
            //cast
            //.ForMember(d => d.SobreNome, o => o.MapFrom(s => s.SobreNome));
            TDominio dominio = Mapper.Map<TDto, TDominio>(model);
            return dominio;
        }

        public virtual TDto Mapeamento(TDominio dominio)
        {
            Mapper.CreateMap<TDominio, TDto>();
            TDto dto = Mapper.Map<TDominio, TDto>(dominio);
            return dto;
        }
    }
}