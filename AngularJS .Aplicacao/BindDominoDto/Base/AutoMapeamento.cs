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
            TDominio usuario = Mapper.Map<TDto, TDominio>(model);
            return usuario;
        }

        public virtual TDto Mapeamento(TDominio dominio)
        {
            Mapper.CreateMap<TDominio, TDto>();
            TDto usuarioModel = Mapper.Map<TDominio, TDto>(dominio);
            return usuarioModel;
        }
    }
}